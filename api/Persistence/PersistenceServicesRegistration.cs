using Application.Abstractions.Services;
using Application.IRepositories;
using Domain.Entities;
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

          #region Microsoft.AspNetCore.Identity

          services.AddIdentity<AppUser, AppRole>(options =>
          {
               options.Password.RequiredLength = 8;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireDigit = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
               options.Password.RequiredUniqueChars = 0;

               options.User.RequireUniqueEmail = true;
          }).AddEntityFrameworkStores<ECommerceDbContext>();

          #endregion

          #region Repositories

          services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
          services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

          services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
          services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

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

          services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
          services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

          services.AddScoped<IOrderReadRepository, OrderReadRepository>();
          services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

          services.AddScoped<IBasketReadRepository, BasketReadRepository>();
          services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

          services.AddScoped<IOfferReadRepository, OfferReadRepository>();
          services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();

          services.AddScoped<IBaseFileReadRepository, BaseFileReadRepository>();
          services.AddScoped<IBaseFileWriteRepository, BaseFileWriteRepository>();

          services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
          services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

          services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
          services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

          #endregion

          #region Services

          services.AddScoped<IAuthService, AuthService>();
          services.AddScoped<IBasketService, BasketService>();

          #endregion

          return services;
     }
}
