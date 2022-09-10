using Application.Features.ProductOperations.Command;
using Application.Features.ProductOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ProductsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetProducts()
          => Ok(await Mediator.Send(new GetProductsQueryRequest()));

     [HttpPost]
     public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
          => Ok(await Mediator.Send(request));
}
