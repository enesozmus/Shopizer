using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OfferReadRepository : ReadRepository<Offer>, IOfferReadRepository
{
     public OfferReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
