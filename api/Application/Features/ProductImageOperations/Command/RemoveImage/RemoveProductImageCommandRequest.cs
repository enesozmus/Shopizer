using MediatR;

namespace Application.Features.ProductImageOperations.Command;

public class RemoveProductImageCommandRequest : IRequest<Unit>
{
     public int Id { get; set; }
     public int? ImageId { get; set; }
}
