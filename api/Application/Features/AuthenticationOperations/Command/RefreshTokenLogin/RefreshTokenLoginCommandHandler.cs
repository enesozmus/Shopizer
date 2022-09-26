using Application.Abstractions.Services;
using Application.DTOs;
using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, Token>
{
     private readonly IAuthService _authService;

     public RefreshTokenLoginCommandHandler(IAuthService authService)
     {
          _authService = authService;
     }

     public async Task<Token> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
     {
          return await _authService.RefreshTokenLoginAsync(request.RefreshToken);
     }
}
