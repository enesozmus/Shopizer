using Application.Abstractions.Hubs;
using Microsoft.Extensions.DependencyInjection;
using SignalR.HubServices;

namespace Persistence;

public static class SignalRServicesRegistration
{
     public static void ConfigureSignalRServices(this IServiceCollection services)
     {
          services.AddTransient<IProductHubService, ProductHubService>();
          services.AddSignalR();

          //return services;
     }
}
