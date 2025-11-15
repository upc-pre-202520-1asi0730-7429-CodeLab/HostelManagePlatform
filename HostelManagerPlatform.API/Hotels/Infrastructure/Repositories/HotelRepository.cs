using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Hotels.Domain.Model.Repositories;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Configuration;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HostelManagerPlatform.API.Hotels.Infrastructure.Repositories;

/// <summary>
/// Implementación del repositorio de HotelSource.  
/// </summary>
/// <remarks>
/// Esta clase implementa las operaciones de persistencia específicas para el agregado HotelSource.
/// </remarks>
/// <param name="context">La instancia de AppDbContext.</param>
public class HotelRepository(AppDbContext context)
    : BaseRepository<Hotel>(context), IHotelRepository
{
    /// <inheritdoc />
    // Se mapea a la query GetAllHotelSourceByAdminIdQuery
    public async Task<IEnumerable<Hotel>> FindByAdminIdAsync(int adminId)
    {
        // Se asume que la propiedad UsersId del agregado se utiliza para filtrar por el ID del administrador.
        return await Context.Set<Hotel>()
            .Where(h => h.UsersId == adminId)
            .ToListAsync();
    }
}