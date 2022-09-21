using Application;
using CrossCuttingConcerns.Exceptions;
using Infrastructure;
using Infrastructure.Services.Storage;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Layers

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);

#endregion

#region Storage

builder.Services.AddStorage<LocalStorage>();

#endregion

#region CORS

builder.Services.AddCors(options => options.AddPolicy("myclients", policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
