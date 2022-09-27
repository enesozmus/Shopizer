using Application.Abstractions.JWT;
using Application.Abstractions.Services;
using Application.DTOs;
using Application.DTOs.Facebook;
using AutoMapper;
using Domain.Entities;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Persistence.Services;

public class AuthService : IAuthService
{
     private readonly UserManager<AppUser> _userManager;
     private readonly SignInManager<AppUser> _signInManager;
     private readonly ITokenHandler _tokenHandler;
     private readonly HttpClient _httpClient;
     readonly IConfiguration _configuration;
     private readonly IMapper _mapper;

     public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
          ITokenHandler tokenHandler, HttpClient httpClient, IConfiguration configuration, IMapper mapper)
     {
          _userManager = userManager;
          _signInManager = signInManager;
          _tokenHandler = tokenHandler;
          _httpClient = httpClient;
          _configuration = configuration;
          _mapper = mapper;
     }

     public async Task<RegisterResponseDTOs> RegisterAsync(RegisterRequestDTOs registerDTOs)
     {
          AppUser userEntity = _mapper.Map<AppUser>(registerDTOs);
          
          IdentityResult result = await _userManager.CreateAsync(userEntity, registerDTOs.Password);

          RegisterResponseDTOs response = new() { IsSucceeded = result.Succeeded };


          if (result.Succeeded)
               response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
          else
               foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

          return response;
     }

     public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
     {
          if (user != null)
          {
               user.RefreshToken = refreshToken;
               // minutes
               user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
               await _userManager.UpdateAsync(user);
          }
          else
               throw new Exception();
     }

     public async Task<Token> LoginAsync(string userName, string password, int accessTokenLifeTime)
     {
          AppUser user = await _userManager.FindByNameAsync(userName);
          if (user == null)
               throw new Exception("Kullanıcı adı veya şifre hatalı!");

          SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
          if (result.Succeeded) //Authentication başarılı!
          {
               Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
               // Refresh Token
               await UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 20);
               return token;
          }
          throw new Exception("Invalid internal authentication!");
     }

     private async Task<Token> CreateUserExternalAsync(AppUser user, string email, string firstName, string lastName, UserLoginInfo info, int accessTokenLifeTime)
     {
          bool result = user != null;
          if (user == null)
          {
               user = await _userManager.FindByEmailAsync(email);
               if (user == null)
               {
                    user = new()
                    {
                         FirstName = firstName,
                         LastName = lastName,
                         Email = email,
                         UserName = email,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
               }
          }

          if (result)
          {
               await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

               Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
               // Refresh Token
               await UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5);
               return token;
          }
          throw new Exception("Invalid external authentication!");
     }

     public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
     {
          var settings = new GoogleJsonWebSignature.ValidationSettings()
          {
               Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
          };

          var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

          var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

          AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

          return await CreateUserExternalAsync(user, payload.Email, payload.GivenName, payload.FamilyName, info, accessTokenLifeTime);
     }

     public async Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
     {
          string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["ExternalLoginSettings:Facebook:Client_ID"]}&client_secret={_configuration["ExternalLoginSettings:Facebook:Client_Secret"]}&grant_type=client_credentials");
          FacebookAccessTokenResponse? facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponse>(accessTokenResponse);
          string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={authToken}&access_token={facebookAccessTokenResponse?.AccessToken}");
          FacebookUserAccessTokenValidation? validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidation);
          if (validation?.Data.IsValid != null)
          {
               string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={authToken}");

               FacebookUserInfoResponse? userInfo = JsonSerializer.Deserialize<FacebookUserInfoResponse>(userInfoResponse);

               var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
               AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

               return await CreateUserExternalAsync(user, userInfo.Email, userInfo.Name, userInfo.Name, info, accessTokenLifeTime);
          }
          throw new Exception("Invalid external authentication!");
     }

     public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
     {
          // user'ların arasında gelen refresh token değeri gelen refresh token değeriyle eşit olan var mı
          AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

          if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
          {
               Token token = _tokenHandler.CreateAccessToken(15, user);
               await UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 20);
               return token;
          }
          else
               throw new Exception();
     }
}
