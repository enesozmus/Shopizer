using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
     private readonly IAuthService _authService;

     public LoginCommandHandler(IAuthService authService)
     {
          _authService = authService;
     }

     public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
     {
          var token = await _authService.LoginAsync(request.UserName, request.Password, 15);
          return new LoginCommandSuccessfulResponse()
          {
               Token = token
          };

          //AppUser user = await _userManager.FindByNameAsync(request.UserName);
          ////AppUser user = await _userManager.FindByEmailAsync(request.Email);
          //if (user == null)
          //     return new LoginCommandUnsuccessfulResponse()
          //     {
          //          Message = "Girdiğiniz kullanıcı adı veri tabanında bulunamadı!"
          //     };
     }
}
