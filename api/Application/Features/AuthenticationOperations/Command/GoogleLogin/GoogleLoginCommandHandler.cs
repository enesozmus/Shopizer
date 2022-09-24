using Application.Abstractions.JWT;
using Application.DTOs;
using Domain.Entities;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.AuthenticationOperations.Command;

public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, Token>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly ITokenHandler _tokenHandler;

     public GoogleLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
     {
          _userManager = userManager;
          _tokenHandler = tokenHandler;
     }

     public async Task<Token> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
     {
          // Client ile ID eşleştirmesi
          var settings = new GoogleJsonWebSignature.ValidationSettings()
          {
               Audience = new List<string> { "310276995424-fib1s6dis96ta147vuamh6mha60kh2o8.apps.googleusercontent.com" }
          };

          // doğrulama
          var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

          var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);

          AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

          bool result = user != null;

          if (user == null)
          {
               user = await _userManager.FindByEmailAsync(payload.Email);
               if (user == null)
               {
                    user = new()
                    {
                         Email = payload.Email,
                         UserName = payload.Email,
                         FirstName = payload.GivenName,
                         LastName = payload.FamilyName
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
               }
          }

          if (result)
               await _userManager.AddLoginAsync(user, info); //AspNetUserLogins
          else
               throw new Exception("Invalid external authentication.");

          return _tokenHandler.CreateAccessToken(5);
     }
}
