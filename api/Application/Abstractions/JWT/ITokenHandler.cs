using Application.DTOs;
using Domain.Entities;

namespace Application.Abstractions.JWT;

public interface ITokenHandler
{
     Token CreateAccessToken(int minute, AppUser appUser);
     string CreateRefreshToken();
}
