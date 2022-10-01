using Application.Features.BasketOperations.Command;
using Application.Features.BasketOperations.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Admin")]
public class BasketsController : BaseController
{
     [HttpPost]
     public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest request)
          => Ok(await Mediator.Send(request));

     [HttpGet]
     public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest request)
          => Ok(await Mediator.Send(request));

     [HttpPut]
     public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest request)
          => Ok(await Mediator.Send(request));

     [HttpDelete("{BasketItemId}")]
     public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest request)
          => Ok(await Mediator.Send(request));
}
