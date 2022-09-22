using MediatR;

namespace Application.Features.ProductImageOperations.Queries;

public class GetProductImagesQueryRequest : IRequest<IReadOnlyList<GetProductImagesQueryResponse>>
{
     public int Id { get; set; }
}