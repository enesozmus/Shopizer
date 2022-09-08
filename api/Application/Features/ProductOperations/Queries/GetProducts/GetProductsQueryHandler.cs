using Application.IRepositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
          var products = await _productReadRepository.GetAsync(include: m => m.Include(x => x.Category).Include(x => x.Brand)
                                                                      .Include(x => x.Color)
                                                                      .Include(x => x.Size)
                                                                      .Include(x => x.AppUser));
          // sonucu eşleyerek gönder
          return _mapper.Map<IReadOnlyList<GetProductsQueryResponse>>(products);
     }
}
