using Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Layers

builder.Services.ConfigurePersistenceServices(builder.Configuration);
//builder.Services.ConfigureApplicationServices();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
