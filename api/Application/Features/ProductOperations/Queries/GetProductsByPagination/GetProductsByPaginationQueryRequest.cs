using Application.Requests;
using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsByPaginationQueryRequest : IRequest<GetProductsByPaginationQueryResponse>
{
     public PageRequest PageRequest { get; set; }
}
