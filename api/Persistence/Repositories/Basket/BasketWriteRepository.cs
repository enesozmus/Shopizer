using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
{
     public BasketWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
