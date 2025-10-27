using HostelManager.API.Hotels.Domain.Model.Aggregates; // Nuevo agregado: HotelSource
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using HostelManager.API.Shared.Infrastructure.Persistence.Configuration.Extensions;

namespace HostelManager.API.Shared.Infrastructure.Persistence.Configuration;

/// <summary>
///     Contexto de base de datos de la aplicación HostelManager
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    // Opcional: Definir un DbSet para tu agregado
    public DbSet<HotelSource> HotelSources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Agregar el interceptor de fechas de creación y actualización
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configuración del Agregado HotelSource
        builder.Entity<HotelSource>().ToTable("HotelSources"); // Nombre de la tabla
        builder.Entity<HotelSource>().HasKey(h => h.Id);
        
        // El ID es requerido y generado por la base de datos
        builder.Entity<HotelSource>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
        
        // Configuración de otras propiedades del HotelSource
        builder.Entity<HotelSource>().Property(h => h.Name).IsRequired().HasMaxLength(100);
        builder.Entity<HotelSource>().Property(h => h.Address).IsRequired().HasMaxLength(255);
        builder.Entity<HotelSource>().Property(h => h.Phone).IsRequired().HasMaxLength(20);
        builder.Entity<HotelSource>().Property(h => h.Imagen).IsRequired(false); // La imagen puede ser opcional
        
        // Configuración de la clave foránea UsersId
        // Asumiendo que UsersId es una FK a una tabla 'Users' o similar
        builder.Entity<HotelSource>().Property(h => h.UsersId).IsRequired(false); // El FK puede ser nulo (int?)
        
        // Usar convención de nombres snake_case para tablas y columnas
        builder.UseSnakeCaseNamingConvention();
    }
}