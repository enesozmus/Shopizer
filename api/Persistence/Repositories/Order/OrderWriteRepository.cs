using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
{
     public OrderWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
