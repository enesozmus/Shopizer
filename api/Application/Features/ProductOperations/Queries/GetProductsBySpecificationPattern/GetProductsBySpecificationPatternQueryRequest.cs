using Application.Requests;
using Application.Specifications;
using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsBySpecificationPatternQueryRequest : IRequest<PaginationForSpec<GetProductsBySpecificationPatternQueryResponse>>
{
     public ProductSpecParams Params { get; set; }
}
