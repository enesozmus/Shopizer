using Application.Features.ColorOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ColorsController : BaseController
{
     [HttpGet]
     public async Task<IActionResult> GetColors()
          => Ok(await Mediator.Send(new GetColorsQueryRequest()));
}
