using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
{
     public BasketItemReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
