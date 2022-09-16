using Application.IRepositories;
using Application.Specifications;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsBySpecificationPatternQueryHandler : IRequestHandler<GetProductsBySpecificationPatternQueryRequest, PaginationForSpec<GetProductsBySpecificationPatternQueryResponse>>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IMapper _mapper;

     public GetProductsBySpecificationPatternQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
     {
          _productReadRepository = productReadRepository;
          _mapper = mapper;
     }

     public async Task<PaginationForSpec<GetProductsBySpecificationPatternQueryResponse>> Handle(GetProductsBySpecificationPatternQueryRequest request, CancellationToken cancellationToken)
     {
          // parametreleri pattern'a gönder
          var spec = new ProductsWithBrandsAndColorSpecification(request.Params);
          var countSpec = new ProductsWithFiltersForCountSpecification(request.Params);

          // ve PaginationForSpec property'lerini üret
          int totalItems = await _productReadRepository.CountAsyncWithSpec(countSpec);
          IReadOnlyList<Product> products = await _productReadRepository.GetListAsyncWithSpec(spec);
          IReadOnlyList<GetProductsBySpecificationPatternQueryResponse> data = _mapper.Map<IReadOnlyList<GetProductsBySpecificationPatternQueryResponse>>(products);


          // sonucu eşleyerek gönder
          return new PaginationForSpec<GetProductsBySpecificationPatternQueryResponse>(
               request.Params.PageIndex, request.Params.PageSize, totalItems, data);
     }
}
