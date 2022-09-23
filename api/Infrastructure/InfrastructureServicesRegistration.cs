using Application.Abstractions.JWT;
using Application.Abstractions.Storage;
using Infrastructure.Enums;
using Infrastructure.Services.JWT;
using Infrastructure.Services.Storage;
using Infrastructure.Services.Storage.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServicesRegistration
{
     public static void ConfigureInfrastructureServices(this IServiceCollection services)
     {
          services.AddScoped<IStorageService, StorageService>();
          services.AddScoped<ITokenHandler, TokenHandler>();
     }

     public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
     {
          serviceCollection.AddScoped<IStorage, T>();
     }

     public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
     {
          switch (storageType)
          {
               case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
               case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
               case StorageType.AWS:

                    break;
               default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
          }
     }

}
