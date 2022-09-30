using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class FilesController : BaseController
{
     private readonly IConfiguration _configuration;

     public FilesController(IConfiguration configuration)
          => _configuration = configuration;

     [HttpGet("[action]")]
     public IActionResult GetBaseStorageUrl()
          => Ok(new { Url = _configuration["BaseStorageUrl:"] });
}
