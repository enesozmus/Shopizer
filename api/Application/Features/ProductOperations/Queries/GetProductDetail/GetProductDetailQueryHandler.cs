using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductOperations.Queries;

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQueryRequest, GetProductDetailQueryResponse>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IMapper _mapper;

     public GetProductDetailQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
     {
          _productReadRepository = productReadRepository;
          _mapper = mapper;
     }

     public async Task<GetProductDetailQueryResponse> Handle(GetProductDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir 
          //Product product = await _productReadRepository.Table
          //          .Include(x => x.Category)
          //          .Include(x => x.Brand)
          //          .Include(x => x.Size)
          //          .Include(x => x.Color)
          //          .Include(x => x.AppUser)
          //          .FirstOrDefaultAsync(x => x.Id == request.Id);


           var product = await _productReadRepository.GetByIdAsyncWithIncludes(predicate: x => x.Id == request.Id, include: m => m.Include(x => x.Category).Include(x => x.Brand)
                                                                       .Include(x => x.Color)
                                                                       .Include(x => x.Size)
                                                                       .Include(x => x.AppUser));

          if (product == null)
               throw new Exception("aaa");

          // sonucu eşleyerek gönder
          return _mapper.Map<GetProductDetailQueryResponse>(product);
     }
}
