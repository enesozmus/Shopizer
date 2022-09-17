using MediatR;

namespace Application.Features.ProductOperations.Command;

public class RemoveProductCommandRequest : IRequest<Unit>
{
     public int Id { get; set; }
}
