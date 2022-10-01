using Application.Abstractions.Services;
using Application.DTOs;
using Application.IRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class BasketService : IBasketService
{
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly UserManager<AppUser> _userManager;
     private readonly IBasketReadRepository _basketReadRepository;
     private readonly IBasketWriteRepository _basketWriteRepository;
     private readonly IBasketItemReadRepository _basketItemReadRepository;
     private readonly IBasketItemWriteRepository _basketItemWriteRepository;
     private readonly IOrderReadRepository _orderReadRepository;

     public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IBasketReadRepository basketReadRepository,
          IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository basketItemReadRepository,
          IBasketItemWriteRepository basketItemWriteRepository, IOrderReadRepository orderReadRepository)
     {
          _httpContextAccessor = httpContextAccessor;
          _userManager = userManager;
          _basketReadRepository = basketReadRepository;
          _basketWriteRepository = basketWriteRepository;
          _basketItemReadRepository = basketItemReadRepository;
          _basketItemWriteRepository = basketItemWriteRepository;
          _orderReadRepository = orderReadRepository;
     }

     private async Task<Basket?> CurrentUserAndBasket()
     {
          // oturum açmış kullanıcıya erişme
          var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

          if (!string.IsNullOrEmpty(username))
          {
               // oturum açmış olan kullanıcıyı varsa sepetleriyle birlikte getirme
               AppUser? user = await _userManager.Users
                    .Include(u => u.Baskets)
                    .FirstOrDefaultAsync(u => u.UserName == username);

               var _basket = from basket in user.Baskets
                             join order in _orderReadRepository.Table
                             on basket.Id equals order.Id into BasketOrder
                             from order in BasketOrder.DefaultIfEmpty()
                             select new
                             {
                                  Basket = basket,
                                  Order = order
                             };

               Basket? targetBasket = null;

               if (_basket.Any(b => b.Order is null))
                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
               else
               {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
               }
               await _basketWriteRepository.SaveAsync();
               return targetBasket;
          }
          throw new Exception();
     }

     public async Task AddItemToBasketAsync(CreateBasketItemDto createBasketItemDto)
     {
          Basket? basket = await CurrentUserAndBasket();

          if (basket != null)
          {
               BasketItem _basketItem = await _basketItemReadRepository.GetFirstAsync(bi => bi.BasketId == basket.Id && bi.ProductId == createBasketItemDto.ProductId);
               if (_basketItem != null)
                    _basketItem.Quantity++;
               else
                    await _basketItemWriteRepository.AddAsync(new()
                    {
                         BasketId = basket.Id,
                         ProductId = createBasketItemDto.ProductId,
                         Quantity = createBasketItemDto.Quantity
                    });
               await _basketItemWriteRepository.SaveAsync();
          }
          else
               throw new Exception();
     }

     public async Task<List<BasketItem>> GetBasketItemsAsync()
     {
          Basket? basket = await CurrentUserAndBasket();

          Basket? result = await _basketReadRepository.Table
               .Include(b => b.BasketItems)
               .ThenInclude(bi => bi.Product)
               .FirstOrDefaultAsync(b => b.Id == basket.Id);

          return result.BasketItems.ToList();
     }

     public async Task UpdateQuantityAsync(UpdateBasketItemDto updateBasketItemDto)
     {
          BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(updateBasketItemDto.BasketItemId);
          if (_basketItem != null)
          {
               _basketItem.Quantity = updateBasketItemDto.Quantity;
               await _basketItemWriteRepository.SaveAsync();
          }
     }

     public async Task RemoveBasketItemAsync(int basketItemId)
     {
          BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
          
          if (basketItem != null)
          {
               await _basketItemWriteRepository.RemoveAsync(basketItem);
               await _basketItemWriteRepository.SaveAsync();
          }
     }
}
