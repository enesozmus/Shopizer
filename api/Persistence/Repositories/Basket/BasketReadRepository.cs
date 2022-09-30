using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
{
     public BasketReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
