using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BuggyController : BaseController
{
     [HttpGet("not-found")]
     public ActionResult GetNotFound() => NotFound();

     [HttpGet("bad-request")]
     public ActionResult GetBadRequest() => BadRequest("This is a bad request");

     [HttpGet("server-error")]
     public ActionResult GetServerError() => StatusCode(500);

     [HttpGet("unauthorised")]
     public ActionResult GetUnauthorised() => Unauthorized();
}
