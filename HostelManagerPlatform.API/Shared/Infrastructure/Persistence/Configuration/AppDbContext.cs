using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Configuration.Extensions;
using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Subscriptions.Domain.Model;

using Microsoft.EntityFrameworkCore;
namespace HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Subscription> Subscriptions { get; set; }  protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(45);
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(45);
        builder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(45);
        builder.Entity<User>().Property(u => u.TypeUser).IsRequired().HasConversion<int>();
        builder.Entity<User>().Property(u => u.SubscriptionId).IsRequired(false);
        
        // Configuración del Agregado Hotel
        builder.Entity<Hotel>().HasKey(h => h.Id);
        
        // El ID es requerido y generado por la base de datos
        builder.Entity<Hotel>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
        
        // Configuración de otras propiedades del HotelSource
        builder.Entity<Hotel>().Property(h => h.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Hotel>().Property(h => h.Address).IsRequired().HasMaxLength(255);
        builder.Entity<Hotel>().Property(h => h.Phone).IsRequired().HasMaxLength(20);
        builder.Entity<Hotel>().Property(h => h.Imagen).IsRequired(false); // La imagen puede ser opcional
        
        // Configuración de la clave foránea UsersId
        // Asumiendo que UsersId es una FK a una tabla 'Users' o similar
        builder.Entity<Hotel>().Property(h => h.UsersId).IsRequired(false); // El FK puede ser nulo (int?)
        builder.Entity<Subscription>().HasKey(s => s.Id);
        builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subscription>().Property(s => s.TypePlan).IsRequired().HasMaxLength(45); // Asumiendo MaxLength 45
        builder.Entity<Subscription>().Property(s => s.NumberCard).IsRequired().HasMaxLength(45); // Asumiendo MaxLength 45
        builder.Entity<Subscription>().Property(s => s.Date).IsRequired().HasMaxLength(45); // Asumiendo MaxLength 45
        builder.Entity<Subscription>().Property(s => s.Cvv).IsRequired().HasMaxLength(45); // Asumiendo MaxLength 45  
        builder.UseSnakeCaseNamingConvention();
    }
}