using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
{
     public BasketItemWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
