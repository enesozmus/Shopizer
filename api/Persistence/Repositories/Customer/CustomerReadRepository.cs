using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
{
     public CustomerReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
