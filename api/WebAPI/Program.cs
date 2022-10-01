using Application;
using CrossCuttingConcerns.Exceptions;
using Infrastructure;
using Infrastructure.Services.Storage.Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using SignalR.HubMapRegistrations;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Text;
using WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Layers

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureSignalRServices();

#endregion

#region Storage

//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();

#endregion

#region CORS

builder.Services.AddCors(options => options.AddPolicy("myclients", policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
));

#endregion

#region HttpClient

builder.Services.AddHttpClient();

#endregion

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
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),

              LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

              NameClaimType = ClaimTypes.Name //JWT üzerinde Name claim'ine karþýlýk gelen deðeri User.Identity.Name propertysinden elde edebiliriz.
         };
    });

#endregion

#region Log

SqlColumn sqlColumn = new SqlColumn();
sqlColumn.ColumnName = "UserName";
sqlColumn.DataType = System.Data.SqlDbType.NVarChar;
sqlColumn.PropertyName = "UserName";
sqlColumn.DataLength = 50;
sqlColumn.AllowNull = true;
ColumnOptions columnOpts = new ColumnOptions();
columnOpts.Store.Remove(StandardColumn.Properties);
columnOpts.Store.Add(StandardColumn.LogEvent);
columnOpts.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };

// Logger log = new LoggerConfiguration().CreateLogger();
Logger log = new LoggerConfiguration()
    // Console'a loglama yap
    .WriteTo.Console()
    // Su dosyaya loglama yap
    .WriteTo.File("logs/log.txt")
    // veri tabanýna loglama yap
    .WriteTo.MSSqlServer(connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
          sinkOptions: new MSSqlServerSinkOptions
          {
               AutoCreateSqlTable = true,
               TableName = "LogEvents",
          }, appConfiguration: null, columnOptions: columnOpts)
    //.WriteTo.Seq(builder.Configuration["Seq:ServerURL"])
    .Enrich.FromLogContext()
    .Enrich.With<CustomUserNameColumnWriter>()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
#endregion

#region MyRegion

//builder.Services.AddHttpLogging(logging =>
//{
//     logging.LoggingFields = HttpLoggingFields.All;
//     logging.RequestHeaders.Add("sec-ch-ua");
//     logging.MediaTypeOptions.AddText("application/javascript");
//     logging.RequestBodyLogLimit = 4096;
//     logging.ResponseBodyLogLimit = 4096;
//});

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

#region Log

//app.UseSerilogRequestLogging();
//app.UseHttpLogging();

#endregion

app.UseCors("myclients");
app.UseHttpsRedirection();

#region Authentication and Authorization

app.UseAuthentication();
app.UseAuthorization();

#endregion

#region Log

app.Use(async (context, next) =>
{
     var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
     LogContext.PushProperty("UserName", username);
     await next();
});

#endregion

app.MapControllers();
app.MapHubs();

app.Run();
