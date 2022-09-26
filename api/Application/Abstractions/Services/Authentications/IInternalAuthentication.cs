using Application.DTOs;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IInternalAuthentication
{
     Task<RegisterResponseDTOs> RegisterAsync(RegisterRequestDTOs registerDTOs);
     Task<Token> LoginAsync(string userName, string password, int accessTokenLifeTime);
     Task<Token> RefreshTokenLoginAsync(string refreshToken);
     Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
}
