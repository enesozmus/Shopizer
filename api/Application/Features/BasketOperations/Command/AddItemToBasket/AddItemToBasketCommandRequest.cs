using MediatR;

namespace Application.Features.BasketOperations.Command;

public class AddItemToBasketCommandRequest : IRequest<Unit>
{
     public int ProductId { get; set; }
     public int Quantity { get; set; }
}
