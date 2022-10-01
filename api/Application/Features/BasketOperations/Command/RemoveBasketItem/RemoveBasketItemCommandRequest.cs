using MediatR;

namespace Application.Features.BasketOperations.Command;

public class RemoveBasketItemCommandRequest : IRequest<Unit>
{
     public int BasketItemId { get; set; }
}
