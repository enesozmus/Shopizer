using Application.Features.ProductOperations.DTOs;
using Application.Paging;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsByPaginationQueryResponse : BasePageableModel
{
     public IList<ProductListDto> Items { get; set; }
}
