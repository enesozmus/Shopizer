using Application.Abstractions.Services;
using Application.DTOs;
using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, Token>
{
     private readonly IAuthService _authService;

     public GoogleLoginCommandHandler(IAuthService authService)
     {
          _authService = authService;
     }

     public async Task<Token> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
     {
          return await _authService.GoogleLoginAsync(request.IdToken, 15);
     }
}
