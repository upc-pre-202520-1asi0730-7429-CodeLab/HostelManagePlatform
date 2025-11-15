using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Hotels.Domain.Model.Queries;
using HostelManagerPlatform.API.Hotels.Domain.Model.Repositories;
using HostelManagerPlatform.API.Hotels.Domain.Model.Services;

namespace HostelManagerPlatform.API.Hotels.Application.Internal.QueryServices;

/// <summary>
/// Servicio de consulta para la entidad HotelSource.
/// </summary>
/// <remarks>
/// Esta clase implementa las operaciones definidas en IHotelSourceQueryService, 
/// utilizando el repositorio para acceder a los datos.
/// </remarks>
/// <param name="hotelRepository">La instancia de IHotelSourceRepository.</param>
public class HotelQueryService(IHotelRepository hotelRepository)
    : IHotelQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Hotel>> Handle(GetAllHotelQuery query)
    {
        // Usa el método FindAllAsync del IBaseRepository (a través de IHotelSourceRepository)
        // para obtener todos los registros.
        return await hotelRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<Hotel?> Handle(GetHotelByIdQuery query)
    {
        // Usa el método FindByIdAsync del IBaseRepository para obtener un único registro por ID.
        return await hotelRepository.FindByIdAsync(query.Id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Hotel>> Handle(GetAllHotelByAdminIdQuery query)
    {
        // Usa el método específico FindByAdminIdAsync que definimos en IHotelSourceRepository.
        return await hotelRepository.FindByAdminIdAsync(query.AdminId);
    }
}