using HostelManager.API.Hotels.Domain.Model.Aggregates;
using HostelManager.API.Hotels.Interfaces.REST.Resource;

namespace HostelManager.API.Hotels.Interfaces.REST.Transform;

/// <summary>
/// Ensambla un HotelSourceResource a partir de una entidad HotelSource. 
/// </summary>
public static class HotelSourceResourceFromEntityAssembler
{
    /// <summary>
    /// Ensambla un HotelSourceResource a partir de una entidad HotelSource. 
    /// </summary>
    /// <param name="entity">La entidad HotelSource</param>
    /// <returns>
    /// Un HotelSourceResource ensamblado a partir de la entidad HotelSource
    /// </returns>
    public static HotelSourceResource ToResourceFromEntity(HotelSource entity) =>
        new HotelSourceResource(
            Id: entity.Id ?? throw new InvalidOperationException("HotelSource entity must have an Id to be converted to a Resource."),
            Name: entity.Name,
            Imagen: entity.Imagen,
            Address: entity.Address,
            Phone: entity.Phone,
            UsersId: entity.UsersId
        );
}