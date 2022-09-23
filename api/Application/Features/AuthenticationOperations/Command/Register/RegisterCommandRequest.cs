using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
{
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public string UserName { get; set; }
     public string Email { get; set; }
     public string Password { get; set; }
     public string PasswordConfirm { get; set; }
}
