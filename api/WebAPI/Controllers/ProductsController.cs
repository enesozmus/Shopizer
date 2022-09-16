using Application.Features.ProductOperations.Command;
using Application.Features.ProductOperations.Queries;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ProductsController : BaseController
{
     // normally
     //[HttpGet]
     //public async Task<IActionResult> GetProducts()
     //     => Ok(await Mediator.Send(new GetProductsQueryRequest()));

     //by SpecificationPattern
     [HttpGet]
     public async Task<IActionResult> GetProductsWithSpec([FromQuery] ProductSpecParams requests)
          => Ok(await Mediator.Send(new GetProductsBySpecificationPatternQueryRequest { Params = requests }));

     // by Pagination
     //[HttpGet]
     //public async Task<IActionResult> GetProductsWithPagination([FromQuery] GetProductsByPaginationQueryRequest request)
     //     => Ok(await Mediator.Send(request));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetProduct(int id)
          => Ok(await Mediator.Send(new GetProductDetailQueryRequest { Id = id }));

     [HttpPost]
     public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
          => Ok(await Mediator.Send(request));
}
