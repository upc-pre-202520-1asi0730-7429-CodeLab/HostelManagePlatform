using HostelManager.API.Hotels.Domain.Model.Aggregates;
using HostelManager.API.Hotels.Domain.Model.Queries;

namespace HostelManager.API.Hotels.Domain.Model.Services;

/// <summary>
///     Interfaz para el servicio de consultas (QueryService) de HotelSource.
/// </summary>
/// <remarks>
///     Esta interfaz define las operaciones para manejar las consultas de lectura relacionadas con la entidad HotelSource.
/// </remarks>
public interface IHotelSourceQueryService
{
    /// <summary>
    ///     Maneja la consulta GetAllHotelSourceQuery.
    /// </summary>
    /// <remarks>
    ///     Este método debe obtener todas las instancias de HotelSource disponibles.
    /// </remarks>
    /// <param name="query">La GetAllHotelSourceQuery query</param>
    /// <returns>Un IEnumerable conteniendo los objetos HotelSource</returns>
    Task<IEnumerable<HotelSource>> Handle(GetAllHotelSourceQuery query);

    /// <summary>
    ///     Maneja la consulta GetHotelSourceByIdQuery.
    /// </summary>
    /// <remarks>
    ///     Este método obtiene una instancia de HotelSource por su identificador único.
    /// </remarks>
    /// <param name="query">La GetHotelSourceByIdQuery query</param>
    /// <returns>
    ///     El objeto HotelSource si se encuentra, o null de lo contrario.
    /// </returns>
    Task<HotelSource?> Handle(GetHotelSourceByIdQuery query);

    /// <summary>
    ///     Maneja la consulta GetAllHotelSourceByAdminIdQuery.
    /// </summary>
    /// <remarks>
    ///     Este método obtiene todas las instancias de HotelSource asociadas a un ID de administrador (UsersId).
    /// </remarks>
    /// <param name="query">La GetAllHotelSourceByAdminIdQuery query</param>
    /// <returns>Un IEnumerable conteniendo los objetos HotelSource asociados al administrador.</returns>
    Task<IEnumerable<HotelSource>> Handle(GetAllHotelSourceByAdminIdQuery query);
}