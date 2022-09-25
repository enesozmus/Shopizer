using Application.DTOs;

namespace Application.Abstractions.Services;

public interface IInternalAuthentication
{
     Task<RegisterResponseDTOs> RegisterAsync(RegisterRequestDTOs registerDTOs);
     Task<Token> LoginAsync(string userName, string password, int accessTokenLifeTime);
}
