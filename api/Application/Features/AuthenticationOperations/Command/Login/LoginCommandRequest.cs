using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
     public string UserName { get; set; }
     public string Password { get; set; }
}
