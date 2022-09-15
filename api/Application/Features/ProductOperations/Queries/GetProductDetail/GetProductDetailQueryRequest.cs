using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetProductDetailQueryRequest : IRequest<GetProductDetailQueryResponse>
{
     public int Id { get; set; }
}
