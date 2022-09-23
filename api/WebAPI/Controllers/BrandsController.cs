using Application.Features.BrandOperations.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Admin")]
public class BrandsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetBrands()
          => Ok(await Mediator.Send(new GetBrandsQueryRequest()));
}
