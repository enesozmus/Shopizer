using Application.Abstractions.JWT;
using Application.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services.JWT;

public class TokenHandler : ITokenHandler
{
     private readonly IConfiguration _configuration;

     public TokenHandler(IConfiguration configuration)
     {
          _configuration = configuration;
     }

     public Token CreateAccessToken(int minute, AppUser appUser)
     {
          var claims = new List<Claim>
          {
               new Claim(ClaimTypes.Name, appUser.UserName),
               new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
               new Claim(ClaimTypes.Email, appUser.Email),
          };

          Token token = new();

          // Security Key'in simetriğini alıyoruz.
          SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

          // Şifrelenmiş kimliği oluşturuyoruz.
          SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

          // Oluşturulacak token ayarlarını veriyoruz.
          token.Expiration = DateTime.UtcNow.AddMinutes(minute);

          JwtSecurityToken securityToken = new(
              audience: _configuration["Token:Audience"],
              issuer: _configuration["Token:Issuer"],
              expires: token.Expiration,
              notBefore: DateTime.UtcNow,
              signingCredentials: signingCredentials,
              claims: claims );

          // Token oluşturucu sınıfından bir örnek alalım.
          JwtSecurityTokenHandler tokenHandler = new();
          token.AccessToken = tokenHandler.WriteToken(securityToken);

          token.RefreshToken = CreateRefreshToken();
          return token;
     }

     public string CreateRefreshToken()
     {
          byte[] number = new byte[32];
          // compailer bu metotun scope'undan çıkana kadar
          using RandomNumberGenerator random = RandomNumberGenerator.Create();
          random.GetBytes(number);
          return Convert.ToBase64String(number);
     }
}
