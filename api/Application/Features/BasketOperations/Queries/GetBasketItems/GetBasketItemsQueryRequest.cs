using MediatR;

namespace Application.Features.BasketOperations.Queries;

public class GetBasketItemsQueryRequest : IRequest<IReadOnlyList<GetBasketItemsQueryResponse>>
{
}
