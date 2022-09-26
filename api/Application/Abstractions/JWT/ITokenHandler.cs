using Application.DTOs;

namespace Application.Abstractions.JWT;

public interface ITokenHandler
{
     Token CreateAccessToken(int minute);
     string CreateRefreshToken();
}
