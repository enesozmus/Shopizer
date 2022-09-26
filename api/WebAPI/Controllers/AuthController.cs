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

     [HttpPost("[action]")]
     public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest request)
          => Ok(await Mediator.Send(request));

     [HttpPost("google-login")]
     public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginCommandRequest request)
          => Ok(await Mediator.Send(request));

     [HttpPost("facebook-login")]
     public async Task<IActionResult> FacebookLogin([FromBody] FacebookLoginCommandRequest request)
          => Ok(await Mediator.Send(request));
}
