using Application.Requests;
using Application.Specifications;
using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetSpecificationsTestQueryRequest : IRequest<PaginationForSpec<GetSpecificationsTestQueryResponse>>
{
     public ProductSpecParams Params { get; set; }
}
