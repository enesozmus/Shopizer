using Application.Abstractions.Storage;
using Application.IRepositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductImageOperations.Command;

public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, Unit>
{
     private readonly IStorageService _storageService;
     readonly IProductReadRepository _productReadRepository;
     readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

     public UploadProductImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository,
          IProductImageFileWriteRepository productImageFileWriteRepository)
     {
          _storageService = storageService;
          _productReadRepository = productReadRepository;
          _productImageFileWriteRepository = productImageFileWriteRepository;
     }

     public async Task<Unit> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
     {
          List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("product-images", request.Images);

          Product product = await _productReadRepository.GetByIdAsync(request.Id);

          await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
          {
               FileName = r.fileName,
               Path = r.pathOrContainerName,
               Storage = _storageService.StorageName,
               Products = new List<Product>() { product }
          }).ToList());

          return Unit.Value;
     }
}
