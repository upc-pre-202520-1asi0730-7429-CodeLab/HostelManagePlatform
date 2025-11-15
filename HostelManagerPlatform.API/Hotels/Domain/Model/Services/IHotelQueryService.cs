using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Hotels.Domain.Model.Queries;

namespace HostelManagerPlatform.API.Hotels.Domain.Model.Services;

public interface IHotelQueryService
{
    /// <summary>
    ///     Maneja la consulta GetAllHotelSourceQuery.
    /// </summary>
    /// <remarks>
    ///     Este método debe obtener todas las instancias de HotelSource disponibles.
    /// </remarks>
    /// <param name="query">La GetAllHotelSourceQuery query</param>
    /// <returns>Un IEnumerable conteniendo los objetos HotelSource</returns>
    Task<IEnumerable<Hotel>> Handle(GetAllHotelQuery query);

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
    Task<Hotel?> Handle(GetHotelByIdQuery query);

    /// <summary>
    ///     Maneja la consulta GetAllHotelSourceByAdminIdQuery.
    /// </summary>
    /// <remarks>
    ///     Este método obtiene todas las instancias de HotelSource asociadas a un ID de administrador (UsersId).
    /// </remarks>
    /// <param name="query">La GetAllHotelSourceByAdminIdQuery query</param>
    /// <returns>Un IEnumerable conteniendo los objetos HotelSource asociados al administrador.</returns>
    Task<IEnumerable<Hotel>> Handle(GetAllHotelByAdminIdQuery query);
}