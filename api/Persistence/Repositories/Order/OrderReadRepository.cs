using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
{
     public OrderReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
