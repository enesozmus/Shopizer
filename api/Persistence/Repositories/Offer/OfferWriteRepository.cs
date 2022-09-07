using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OfferWriteRepository : WriteRepository<Offer>, IOfferWriteRepository
{
     public OfferWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
