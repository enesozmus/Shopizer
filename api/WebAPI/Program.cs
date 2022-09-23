using Application;
using CrossCuttingConcerns.Exceptions;
using Infrastructure;
using Infrastructure.Services.Storage.Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Layers

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);

#endregion

#region Storage

//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();

#endregion

#region CORS

builder.Services.AddCors(options => options.AddPolicy("myclients", policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Jwt Bearer Defaults

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
         options.TokenValidationParameters = new()
         {
              ValidateAudience = true,
              ValidateIssuer = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidAudience = builder.Configuration["Token:Audience"],
              ValidIssuer = builder.Configuration["Token:Issuer"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
         };
    });

#endregion

#region Swagger

builder.Services.AddSwaggerGen(options =>
{
     options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
     options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
     {
          Description = "Jwt auth header",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
     });
     options.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
          {
               new OpenApiSecurityScheme
               {
                    Reference = new OpenApiReference
                    {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
               },
               new List<string>()
          }
     });
});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

#region Global Exception Handler

//if (app.Environment.IsProduction())
//     app.ConfigureCustomExceptionMiddleware();

app.ConfigureCustomExceptionMiddleware();

#endregion

// wwwroot
app.UseStaticFiles();

app.UseCors("myclients");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
