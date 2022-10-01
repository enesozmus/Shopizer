using Application.DTOs;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IBasketService
{
     public Task<List<BasketItem>> GetBasketItemsAsync();
     public Task AddItemToBasketAsync(CreateBasketItemDto createBasketItemDto);
     public Task UpdateQuantityAsync(UpdateBasketItemDto updateBasketItemDto);
     public Task RemoveBasketItemAsync(int basketItemId);
}
