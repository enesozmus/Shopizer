using MediatR;

namespace Application.Features.BasketOperations.Command;

public class UpdateQuantityCommandRequest : IRequest<Unit>
{
     public int BasketItemId { get; set; }
     public int Quantity { get; set; }
}
