using Application.Features.ProductOperations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ProductsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetProducts()
          => Ok(await Mediator.Send(new GetProductsQueryRequest()));
}
