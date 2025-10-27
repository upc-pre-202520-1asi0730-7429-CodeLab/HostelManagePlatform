using HostelManager.API.Hotels.Domain.Model.Aggregates;
using HostelManager.API.Hotels.Domain.Model.Queries;
using HostelManager.API.Hotels.Domain.Model.Repositories;
using HostelManager.API.Hotels.Domain.Model.Services;

namespace HostelManager.API.Hotels.Application.Internal.QueryServices;

/// <summary>
/// Servicio de consulta para la entidad HotelSource.
/// </summary>
/// <remarks>
/// Esta clase implementa las operaciones definidas en IHotelSourceQueryService, 
/// utilizando el repositorio para acceder a los datos.
/// </remarks>
/// <param name="hotelSourceRepository">La instancia de IHotelSourceRepository.</param>
public class HotelSourceQueryService(IHotelSourceRepository hotelSourceRepository)
    : IHotelSourceQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<HotelSource>> Handle(GetAllHotelSourceQuery query)
    {
        // Usa el método FindAllAsync del IBaseRepository (a través de IHotelSourceRepository)
        // para obtener todos los registros.
        return await hotelSourceRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<HotelSource?> Handle(GetHotelSourceByIdQuery query)
    {
        // Usa el método FindByIdAsync del IBaseRepository para obtener un único registro por ID.
        return await hotelSourceRepository.FindByIdAsync(query.Id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<HotelSource>> Handle(GetAllHotelSourceByAdminIdQuery query)
    {
        // Usa el método específico FindByAdminIdAsync que definimos en IHotelSourceRepository.
        return await hotelSourceRepository.FindByAdminIdAsync(query.AdminId);
    }
}