using Application.IRepositories;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Services;

namespace Persistence;

public static class PersistenceServicesRegistration
{
     public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
     {
          #region Microsoft SQL Server

          services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

          #endregion

          #region Repositories

          services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
          services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

          services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
          services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

          services.AddScoped<IBrandReadRepository, BrandReadRepository>();
          services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

          services.AddScoped<IColorReadRepository, ColorReadRepository>();
          services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

          services.AddScoped<ISizeReadRepository, SizeReadRepository>();
          services.AddScoped<ISizeWriteRepository, SizeWriteRepository>();

          services.AddScoped<IProductReadRepository, ProductReadRepository>();
          services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

          services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
          services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

          services.AddScoped<IOfferReadRepository, OfferReadRepository>();
          services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();

          services.AddScoped<IOrderReadRepository, OrderReadRepository>();
          services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

          services.AddScoped<IBaseFileReadRepository, BaseFileReadRepository>();
          services.AddScoped<IBaseFileWriteRepository, BaseFileWriteRepository>();

          services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
          services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

          services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
          services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

          #endregion

          #region Services

          services.AddScoped<IFileService, FileService>();

          #endregion

          return services;
     }
}
