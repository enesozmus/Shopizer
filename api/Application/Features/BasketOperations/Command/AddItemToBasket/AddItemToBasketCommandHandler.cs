using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.BasketOperations.Command;

public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, Unit>
{
     private readonly IBasketService _basketService;

     public AddItemToBasketCommandHandler(IBasketService basketService)
          => _basketService = basketService;

     public async Task<Unit> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
     {
          await _basketService.AddItemToBasketAsync(new()
          {
               ProductId = request.ProductId,
               Quantity = request.Quantity
          });

          return Unit.Value;
     }
}
