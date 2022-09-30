using Application.IRepositories;
using Application.Paging;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsByPaginationQueryHandler : IRequestHandler<GetProductsByPaginationQueryRequest, GetProductsByPaginationQueryResponse>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IMapper _mapper;

     public GetProductsByPaginationQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
     {
          _productReadRepository = productReadRepository;
          _mapper = mapper;
     }

     public async Task<GetProductsByPaginationQueryResponse> Handle(GetProductsByPaginationQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          IPaginate<Product> products = await _productReadRepository.
               GetListAsPaginateAsync(include: m => m.Include(x => x.Brand).Include(x => x.ProductImageFiles),
               index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize);

          // eşle
          GetProductsByPaginationQueryResponse mappedProducts = _mapper.Map<GetProductsByPaginationQueryResponse>(products);

          // sonucu gönder
          return mappedProducts;
     }
}
