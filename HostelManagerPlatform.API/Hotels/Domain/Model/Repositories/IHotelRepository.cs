using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Shared.Domain.Repositories;

namespace HostelManagerPlatform.API.Hotels.Domain.Model.Repositories;

public interface IHotelRepository: IBaseRepository<Hotel>
{
    /// <summary>
    /// Busca todas las fuentes de hoteles asociadas a un ID de administrador (UsersId).
    /// Corresponde a la query GetAllHotelSourceByAdminIdQuery.
    /// </summary>
    /// <param name="adminId">El ID del administrador (UsersId) para buscar.</param>
    /// <returns>
    /// Un Enumerable de objetos HotelSource si se encuentran, o vacío en caso contrario.
    /// </returns>
    Task<IEnumerable<Hotel>> FindByAdminIdAsync(int adminId);
}