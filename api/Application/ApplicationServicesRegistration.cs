using Application.Pipelines.Validation;
using FluentValidation;
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

          // FluentValidation
          services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

          // MediatR Pipeline Behaviour
          services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
          
          return services;
     }
}
