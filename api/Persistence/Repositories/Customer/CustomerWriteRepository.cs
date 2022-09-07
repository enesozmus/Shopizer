using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
{
     public CustomerWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
