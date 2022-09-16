using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProductOperations.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, IReadOnlyList<GetProductsQueryResponse>>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IMapper _mapper;

     public GetProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
     {
          _productReadRepository = productReadRepository;
          _mapper = mapper;
     }

     public async Task<IReadOnlyList<GetProductsQueryResponse>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var products = await _productReadRepository.GetAllAsync();

          // sonucu eşleyerek gönder
          return _mapper.Map<IReadOnlyList<GetProductsQueryResponse>>(products);
     }
}
