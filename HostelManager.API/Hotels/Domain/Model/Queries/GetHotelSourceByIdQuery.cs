namespace HostelManager.API.Hotels.Domain.Model.Queries;

/// <summary>
///     Query para obtener una instancia específica de HotelSource por su identificador único.
/// </summary>
/// <param name="Id">El identificador (ID) del HotelSource a buscar.</param>
public record GetHotelSourceByIdQuery(int Id);