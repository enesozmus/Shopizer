using Application.DTOs;
using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class FacebookLoginCommandRequest : IRequest<Token>
{
     public string AuthToken { get; set; }
}
