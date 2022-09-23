using Application.DTOs;

namespace Application.Features.AuthenticationOperations.Command;

public class LoginCommandResponse { }

public class LoginCommandSuccessfulResponse : LoginCommandResponse
{
     public Token? Token { get; set; }
}

public class LoginCommandUnsuccessfulResponse : LoginCommandResponse
{
     public string Message { get; set; }
}