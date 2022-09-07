using Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServicesRegistration
{
     public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
     {
          #region Microsoft SQL Server

          services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

          #endregion

          #region Commons

          services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
          services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

          #endregion

          #region Repositories

          services.AddScoped<IBaseFileReadRepository, BaseFileReadRepository>();
          services.AddScoped<IBaseFileWriteRepository, BaseFileWriteRepository>();

          services.AddScoped<IBrandReadRepository, BrandReadRepository>();
          services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

          services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
          services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

          services.AddScoped<IColorReadRepository, ColorReadRepository>();
          services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

          services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
          services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

          services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
          services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

          services.AddScoped<IOfferReadRepository, OfferReadRepository>();
          services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();

          services.AddScoped<IOrderReadRepository, OrderReadRepository>();
          services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

          services.AddScoped<IProductReadRepository, ProductReadRepository>();
          services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

          services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
          services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

          services.AddScoped<ISizeReadRepository, SizeReadRepository>();
          services.AddScoped<ISizeWriteRepository, SizeWriteRepository>();

          #endregion

          return services;
     }
}
