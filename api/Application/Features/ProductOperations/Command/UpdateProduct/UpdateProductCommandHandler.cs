using Application.IRepositories;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.ProductOperations.Command;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IProductWriteRepository _productWriteRepository;
     readonly ILogger<UpdateProductCommandHandler> _logger;

     public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository,
          ILogger<UpdateProductCommandHandler> logger)
     {
          _productReadRepository = productReadRepository;
          _productWriteRepository = productWriteRepository;
          _logger = logger;
     }

     public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
     {
          Product product = await _productReadRepository.GetByIdAsync(request.Id);

          if (product != null)
          {
               product.Name = request.Name;
               product.Stock = request.Stock;
               product.Price = request.Price;
               product.IsOfferable = request.IsOfferable;
               product.IsSold = request.IsSold;
               product.CategoryId = request.CategoryId;
               product.BrandId = request.BrandId;
               product.SizeId = request.SizeId;
               product.AppUserId = request.AppUserId;

               await _productWriteRepository.SaveAsync();
               _logger.LogInformation("--Ürün güncellendi...");
               return Unit.Value;
          }
          throw new Exception();
     }
}
