using Application.Abstractions.Services;
using Application.DTOs;
using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, Token>
{
     private readonly IAuthService _authService;

     public FacebookLoginCommandHandler(IAuthService authService)
     {
          _authService = authService;
     }

     public async Task<Token> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
     {
          return await _authService.FacebookLoginAsync(request.AuthToken, 15);
     }
}
