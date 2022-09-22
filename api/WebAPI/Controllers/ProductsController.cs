using Application.Abstractions.Storage;
using Application.Features.ProductOperations.Command;
using Application.Features.ProductOperations.Queries;
using Application.IRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers;

public class ProductsController : BaseController
{
     private readonly IStorageService _storageService;
     private readonly IProductImageFileReadRepository _productImageFileReadRepository;
     private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
     private readonly IProductReadRepository _productReadRepository;
     readonly IConfiguration _configuration;


     public ProductsController(IStorageService storageService, IProductImageFileWriteRepository productImageFileWriteRepository,
          IProductReadRepository productReadRepository, IProductImageFileReadRepository productImageFileReadRepository, IConfiguration configuration)
     {
          _storageService = storageService;
          _productImageFileWriteRepository = productImageFileWriteRepository;
          _productReadRepository = productReadRepository;
          _productImageFileReadRepository = productImageFileReadRepository;
          _configuration = configuration;
     }

     // normally
     //[HttpGet]
     //public async Task<IActionResult> GetProducts()
     //     => Ok(await Mediator.Send(new GetProductsQueryRequest()));

     //by SpecificationPattern
     //[HttpGet]
     //public async Task<IActionResult> GetProductsWithSpec([FromQuery] ProductSpecParams requests)
     //     => Ok(await Mediator.Send(new GetProductsBySpecificationPatternQueryRequest { Params = requests }));

     // by Pagination
     [HttpGet("withParamaters")]
     public async Task<IActionResult> GetProductsWithPagination([FromQuery] GetProductsByPaginationQueryRequest request)
          => Ok(await Mediator.Send(request));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetProduct(int id)
          => Ok(await Mediator.Send(new GetProductDetailQueryRequest { Id = id }));

     [HttpPost]
     public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
          => Ok(await Mediator.Send(request));

     [HttpDelete("{id}")]
     public async Task<IActionResult> RemoveProduct(int id)
          => Ok(await Mediator.Send(new RemoveProductCommandRequest { Id = id }));

     // query string
     [HttpPost("[action]")]
     public async Task<IActionResult> Upload(int id)
     {
          List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("product-images", Request.Form.Files);

          Product product = await _productReadRepository.GetByIdAsync(id);

          await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
          {
               FileName = r.fileName,
               Path = r.pathOrContainerName,
               Storage = _storageService.StorageName,
               Products = new List<Product>() { product }
          }).ToList());
          return Ok();
     }

     // route
     [HttpGet("[action]/{id}")]
     public async Task<IActionResult> GetProductImages(int id)
     {
          Product? product = await _productReadRepository.Table
               // eager loading
               .Include(p => p.ProductImageFiles)
               .FirstOrDefaultAsync(p => p.Id == id);

          // elimizdeki ürünün resimlerini dön
          if (product != null)
          {
               return Ok(product.ProductImageFiles.Select(p => new
               {
                    p.Id,
                    Path = $"{_configuration["BaseStorageUrl:"]}/{p.Path}",
                    p.FileName
               }));
          }
          return BadRequest();
     }

     [HttpDelete("[action]/{id}")]
     public async Task<IActionResult> DeleteProductImage(int id, int imageId)
     {
          Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == id);
          if (product != null)
          {
               ProductImageFile productImageFile = product.ProductImageFiles.FirstOrDefault(p => p.Id == imageId);

               if (productImageFile != null)
                    product.ProductImageFiles.Remove(productImageFile);
               return Ok();
          }
          return NotFound();
     }
}
