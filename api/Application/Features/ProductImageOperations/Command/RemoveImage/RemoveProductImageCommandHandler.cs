using Application.IRepositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductImageOperations.Command;

public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, Unit>
{
     private readonly IProductReadRepository _productReadRepository;
     private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

     public RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
     {
          _productReadRepository = productReadRepository;
          _productImageFileWriteRepository = productImageFileWriteRepository;
     }

     public async Task<Unit> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
     {
          // önce ürünü getir
          Product? product = await _productReadRepository.Table
               .Include(p => p.ProductImageFiles)
               .FirstOrDefaultAsync(p => p.Id == request.Id);

          if (product != null)
          {
               // o ürüne ait o resmi getir  
               ProductImageFile? productImageFile = product.ProductImageFiles.FirstOrDefault(p => p.Id == request.ImageId);

               if (productImageFile != null)
                    await _productImageFileWriteRepository.RemoveAsync(productImageFile);
          }
          return Unit.Value;
     }
}
