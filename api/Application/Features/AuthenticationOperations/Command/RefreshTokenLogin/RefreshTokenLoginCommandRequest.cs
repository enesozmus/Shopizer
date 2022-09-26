using Application.DTOs;
using MediatR;

namespace Application.Features.AuthenticationOperations.Command;

public class RefreshTokenLoginCommandRequest : IRequest<Token>
{
     public string RefreshToken { get; set; }
}
