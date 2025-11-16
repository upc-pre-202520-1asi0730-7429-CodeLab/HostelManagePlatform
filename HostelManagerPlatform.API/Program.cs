using HostelManagerPlatform.API.Hotels.Application.Internal.CommandServices;
using HostelManagerPlatform.API.Hotels.Application.Internal.QueryServices;
using HostelManagerPlatform.API.Hotels.Domain.Model.Repositories;
using HostelManagerPlatform.API.Hotels.Domain.Model.Services;
using HostelManagerPlatform.API.Hotels.Infrastructure.Repositories;
using HostelManagerPlatform.API.Shared.Domain.Repositories;
using HostelManagerPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Configuration;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Repositories;
using HostelManagerPlatform.API.Users.Application.Internal.CommandServices;
using HostelManagerPlatform.API.Users.Application.Internal.QueryServices;
using HostelManagerPlatform.API.Users.Domain.Model.Repositories;
using HostelManagerPlatform.API.Users.Domain.Model.Services;
using HostelManagerPlatform.API.Users.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddLocalization();
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddDataAnnotationsLocalization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (connectionString is null)
                throw new Exception("Could not find connection string");
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    );
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.Production.{builder.Environment.EnvironmentName}.json", optional: true,
                reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        var connectionStringTemplate = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionStringTemplate))
            throw new Exception("Could not find connection string");
        var connectionString = Environment.ExpandEnvironmentVariables(connectionStringTemplate);
        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("Could not resolve connection string");
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelCommandService, HotelCommandService>();
builder.Services.AddScoped<IHotelQueryService, HotelQueryService>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

var supportedCultures = new[] { "en", "en-US", "es", "es-PE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[2])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

localizationOptions.ApplyCurrentCultureToResponseHeaders = true;
app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();