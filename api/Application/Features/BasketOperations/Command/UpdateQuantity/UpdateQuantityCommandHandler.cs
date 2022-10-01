using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.BasketOperations.Command;


public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, Unit>
{
     private readonly IBasketService _basketService;

     public UpdateQuantityCommandHandler(IBasketService basketService)
     {
          _basketService = basketService;
     }

     public async Task<Unit> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
     {
          await _basketService.UpdateQuantityAsync(new()
          {
               BasketItemId = request.BasketItemId,
               Quantity = request.Quantity
          });

          return Unit.Value;
     }
}
