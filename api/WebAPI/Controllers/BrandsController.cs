using Application.Features.BrandOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BrandsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetBrands()
          => Ok(await Mediator.Send(new GetBrandsQueryRequest()));
}
