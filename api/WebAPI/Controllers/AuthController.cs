using Application.Features.AuthenticationOperations.Command;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class AuthController : BaseController
{
     [HttpPost]
     public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request)
          => Ok(await Mediator.Send(request));

     [HttpPost("[action]")]
     public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
          => Ok(await Mediator.Send(request));
}
