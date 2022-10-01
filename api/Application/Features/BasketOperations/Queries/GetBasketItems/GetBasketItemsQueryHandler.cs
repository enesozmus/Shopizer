using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.BasketOperations.Queries;

public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, IReadOnlyList<GetBasketItemsQueryResponse>>
{
     private readonly IBasketService _basketService;

     public GetBasketItemsQueryHandler(IBasketService basketService)
     {
          _basketService = basketService;
     }

     public async Task<IReadOnlyList<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
     {
          var basketItems = await _basketService.GetBasketItemsAsync();
          return basketItems.Select(ba => new GetBasketItemsQueryResponse
          {
               BasketItemId = ba.Id,
               Name = ba.Product.Name,
               Price = ba.Product.Price,
               Quantity = ba.Quantity
          }).ToList();
     }
}
