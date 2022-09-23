using Application.Abstractions.JWT;
using Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infrastructure.Services.JWT;

public class TokenHandler : ITokenHandler
{
     private readonly IConfiguration _configuration;

     public TokenHandler(IConfiguration configuration)
     {
          _configuration = configuration;
     }

     public Token CreateAccessToken(int minute)
     {
          Token token = new();

          //Security Key'in simetriğini alıyoruz.
          SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

          //Şifrelenmiş kimliği oluşturuyoruz.
          SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

          //Oluşturulacak token ayarlarını veriyoruz.
          token.Expiration = DateTime.UtcNow.AddMinutes(minute);

          JwtSecurityToken securityToken = new(
              audience: _configuration["Token:Audience"],
              issuer: _configuration["Token:Issuer"],
              expires: token.Expiration,
              notBefore: DateTime.UtcNow,
              signingCredentials: signingCredentials);

          //Token oluşturucu sınıfından bir örnek alalım.
          JwtSecurityTokenHandler tokenHandler = new();
          token.AccessToken = tokenHandler.WriteToken(securityToken);
          return token;
     }
}
