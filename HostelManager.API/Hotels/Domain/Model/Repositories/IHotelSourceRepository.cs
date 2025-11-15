using HostelManager.API.Hotels.Domain.Model.Aggregates;
using HostelManager.API.Shared.Domain.Repositories; 

namespace HostelManager.API.Hotels.Domain.Model.Repositories;

/// <summary>
/// El contrato del repositorio para la fuente de hoteles (HotelSource).  
/// Hereda de IBaseRepository para las operaciones CRUD básicas.
/// </summary>
public interface IHotelSourceRepository : IBaseRepository<HotelSource>
{
    /// <summary>
    /// Busca todas las fuentes de hoteles asociadas a un ID de administrador (UsersId).
    /// Corresponde a la query GetAllHotelSourceByAdminIdQuery.
    /// </summary>
    /// <param name="adminId">El ID del administrador (UsersId) para buscar.</param>
    /// <returns>
    /// Un Enumerable de objetos HotelSource si se encuentran, o vacío en caso contrario.
    /// </returns>
    Task<IEnumerable<HotelSource>> FindByAdminIdAsync(int adminId);
}