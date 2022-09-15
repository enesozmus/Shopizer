using Application.Features.ProductOperations.Command;
using Application.Features.ProductOperations.Queries;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ProductsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetProducts()
          => Ok(await Mediator.Send(new GetProductsQueryRequest()));

     [HttpGet("testSpec")]
     public async Task<IActionResult> GetProductsWithSpec([FromQuery] ProductSpecParams requests)
          => Ok(await Mediator.Send(new GetSpecificationsTestQueryRequest { Params = requests }));

     [HttpGet("{id}")]
     public async Task<IActionResult> GetProduct(int id)
          => Ok(await Mediator.Send(new GetProductDetailQueryRequest { Id = id }));

     [HttpPost]
     public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
          => Ok(await Mediator.Send(request));
}
