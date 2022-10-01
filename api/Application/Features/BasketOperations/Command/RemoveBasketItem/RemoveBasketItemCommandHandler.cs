using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.BasketOperations.Command;

public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommandRequest, Unit>
{
     private readonly IBasketService _basketService;

     public RemoveBasketItemCommandHandler(IBasketService basketService)
     {
          _basketService = basketService;
     }

     public async Task<Unit> Handle(RemoveBasketItemCommandRequest request, CancellationToken cancellationToken)
     {
          await _basketService.RemoveBasketItemAsync(request.BasketItemId);
          return Unit.Value;
     }
}
