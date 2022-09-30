using Application.IRepositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Features.ProductImageOperations.Queries;

public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, IReadOnlyList<GetProductImagesQueryResponse>>
{
     private readonly IProductReadRepository _productReadRepository;
     readonly IConfiguration _configuration;

     public GetProductImagesQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
     {
          _productReadRepository = productReadRepository;
          _configuration = configuration;
     }

     public async Task<IReadOnlyList<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
     {
          // önce ürünü getir
          Product? product = await _productReadRepository.Table
               .Include(p => p.ProductImageFiles)
               .FirstOrDefaultAsync(p => p.Id == request.Id);


          // elimizdeki ürünün resimlerini dön
          if (product != null)
          {
               return product.ProductImageFiles.Select(p => new GetProductImagesQueryResponse
               {
                    Id = p.Id,
                    Showcase = p.Showcase,
                    Path = $"{_configuration["BaseStorageUrl:"]}/{p.Path}",
                    FileName = p.FileName
               }).ToList();
          }
          return null;
     }
}
