using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;

public static class PersistenceServicesRegistration
{
     public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
     {
          #region Microsoft SQL Server

          services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

          #endregion

          return services;
     }
}
