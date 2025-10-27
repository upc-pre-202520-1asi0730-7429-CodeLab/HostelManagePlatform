using HostelManager.API.Hotels.Domain.Model.Aggregates;
using HostelManager.API.Shared.Infrastructure.Persistence.Configuration;
using HostelManager.API.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using HostelManager.API.Hotels.Domain.Model.Repositories;

namespace HostelManager.API.Hotels.Infrastructure.Repositories;

/// <summary>
/// Implementación del repositorio de HotelSource.  
/// </summary>
/// <remarks>
/// Esta clase implementa las operaciones de persistencia específicas para el agregado HotelSource.
/// </remarks>
/// <param name="context">La instancia de AppDbContext.</param>
public class HotelSourceRepository(AppDbContext context)
    : BaseRepository<HotelSource>(context), IHotelSourceRepository
{
    /// <inheritdoc />
    // Se mapea a la query GetAllHotelSourceByAdminIdQuery
    public async Task<IEnumerable<HotelSource>> FindByAdminIdAsync(int adminId)
    {
        // Se asume que la propiedad UsersId del agregado se utiliza para filtrar por el ID del administrador.
        return await Context.Set<HotelSource>()
            .Where(h => h.UsersId == adminId)
            .ToListAsync();
    }
}