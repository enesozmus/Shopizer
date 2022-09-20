﻿using Application.Features.ProductOperations.Command;
using Application.Features.ProductOperations.Queries;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ProductsController : BaseController
{
     private readonly IWebHostEnvironment _webHostEnvironment;
     private readonly IFileService _fileService;

     public ProductsController(IWebHostEnvironment webHostEnvironment, IFileService fileService)
     {
          _webHostEnvironment = webHostEnvironment;
          _fileService = fileService;
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


     [HttpPost("[action]")]
     public async Task<IActionResult> Upload()
     {
          await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
          return Ok();
     }

     //[HttpPost("[action]")]
     //public async Task<IActionResult> Upload()
     //{
     //     // wwwroot/resource/product-images
     //     string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");

     //     if (!Directory.Exists(uploadPath))
     //          Directory.CreateDirectory(uploadPath);

     //     Guid guid = Guid.NewGuid();
     //     foreach (IFormFile file in Request.Form.Files)
     //     {
     //          string noExtension = Path.GetFileNameWithoutExtension(file.FileName).ToLower()
     //               .Replace(" ", "-")
     //               .Replace("ğ", "g")
     //               .Replace("ı", "i")
     //               .Replace("ö", "o")
     //               .Replace("ü", "u")
     //               .Replace("ş", "s")
     //               .Replace("ç", "c")
     //               .Replace("Ç", "c")
     //               .Replace("Ş", "s")
     //               .Replace("Ğ", "g")
     //               .Replace("Ü", "u")
     //               .Replace("İ", "i")
     //               .Replace("Ö", "o")
     //               .Trim();

     //          string fullPath = Path.Combine(uploadPath, $"{noExtension + "-"}{guid}{Path.GetExtension(file.FileName)}");

     //          using FileStream fileStream = new
     //               (fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

     //          await file.CopyToAsync(fileStream);
     //          await fileStream.FlushAsync();
     //     }
     //     return Ok();
     //}
}
