using Application.Features.ProductImageOperations.Command;
using Application.Features.ProductImageOperations.Queries;
using Application.Features.ProductOperations.Command;
using Application.Features.ProductOperations.Queries;
using Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ProductsController : BaseController
{
     // normal
     //[HttpGet]
     //public async Task<IActionResult> GetProducts()
     //     => Ok(await Mediator.Send(new GetProductsQueryRequest()));

     ////by SpecificationPattern
     //[HttpGet]
     //public async Task<IActionResult> GetProductsWithSpec([FromQuery] ProductSpecParams requests)
     //     => Ok(await Mediator.Send(new GetProductsBySpecificationPatternQueryRequest { Params = requests }));

     // by Pagination for Admin
     [Authorize(AuthenticationSchemes = "Admin")]
     [HttpGet("withParamaters")]
     public async Task<IActionResult> GetProductsWithPagination([FromQuery] GetProductsByPaginationQueryRequest request)
          => Ok(await Mediator.Send(request));

     [HttpGet("{Id}")]
     public async Task<IActionResult> GetProduct([FromRoute] GetProductDetailQueryRequest request)
          => Ok(await Mediator.Send(request));

     [HttpPost]
     public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
          => Ok(await Mediator.Send(request));

     [HttpDelete("{Id}")]
     public async Task<IActionResult> RemoveProduct([FromRoute]RemoveProductCommandRequest request)
          => Ok(await Mediator.Send(request));

     // query string
     [HttpPost("[action]")]
     public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest request)
     {
          request.Images = Request.Form.Files;
          return Ok(await Mediator.Send(request));
     }

     #region Test
     //[HttpPost("[action]")]
     //public async Task<IActionResult> Upload([FromQuery, FromForm] UploadProductImageCommandRequest request)
     //{
     //     //request.Images = Request.Form.Files;
     //     return Ok(await Mediator.Send(request));
     //}

     #endregion

     // route
     [HttpGet("[action]/{id}")]
     public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest request)
          => Ok(await Mediator.Send(request));

     // delete image
     [HttpDelete("[action]/{id}")]
     public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest request, [FromQuery] int imageId)
     {
          request.ImageId = imageId;
          return Ok(await Mediator.Send(request));
     }
}
