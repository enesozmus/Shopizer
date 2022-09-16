using Application.Features.SizeOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class SizesController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetSizes()
          => Ok(await Mediator.Send(new GetSizesQueryRequest()));
}
