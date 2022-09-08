using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServicesRegistration
{
     public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
     {
          // MediatR
          services.AddMediatR(Assembly.GetExecutingAssembly());

          // AutoMapper
          services.AddAutoMapper(Assembly.GetExecutingAssembly());

          return services;
     }
}
