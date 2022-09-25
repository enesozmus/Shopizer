using Application.DTOs;

namespace Application.Abstractions.Services;

public interface IExternalAuthentication
{
     Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
     Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);

     //Task<Token> TwitterLoginAsync();
}
