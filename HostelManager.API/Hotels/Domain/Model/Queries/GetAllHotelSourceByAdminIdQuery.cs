namespace HostelManager.API.Hotels.Domain.Model.Queries;

/// <summary>
///     Query para obtener todas las instancias de HotelSource asociadas a un administrador/usuario específico.
/// </summary>
/// <param name="AdminId">El identificador (ID) del administrador/usuario para buscar los hoteles asociados (UsersId).</param>
public record GetAllHotelSourceByAdminIdQuery(int AdminId);