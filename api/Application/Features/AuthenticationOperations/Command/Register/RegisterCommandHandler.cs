using Application.Abstractions.Services;
using Application.DTOs;
using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
     private readonly IAuthService _authService;

     public RegisterCommandHandler(IAuthService authService)
     {
          _authService = authService;
     }

     public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
     {

          RegisterResponseDTOs response = await _authService.RegisterAsync(new()
          {
               FirstName = request.FirstName,
               LastName = request.LastName,
               UserName = request.UserName,
               Email = request.Email,
               Password = request.Password,
               PasswordConfirm = request.PasswordConfirm
          });

          return new()
          {
               Message = response.Message,
               IsSucceeded = response.IsSucceeded
          };
     }
}
