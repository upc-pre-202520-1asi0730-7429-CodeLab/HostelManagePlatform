using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Hotels.Interfaces.REST.Resource;

namespace HostelManagerPlatform.API.Hotels.Interfaces.REST.Transform;

/// <summary>
/// Ensambla un HotelSourceResource a partir de una entidad HotelSource. 
/// </summary>
public class HotelResourceFromEntityAssembler
{
    /// <summary>
    /// Ensambla un HotelSourceResource a partir de una entidad HotelSource. 
    /// </summary>
    /// <param name="entity">La entidad HotelSource</param>
    /// <returns>
    /// Un HotelSourceResource ensamblado a partir de la entidad HotelSource
    /// </returns>
    public static HotelResource ToResourceFromEntity(Hotel entity) =>
        new HotelResource(
            Id: entity.Id ?? throw new InvalidOperationException("Hotel entity must have an Id to be converted to a Resource."),
            Name: entity.Name,
            Imagen: entity.Imagen,
            Address: entity.Address,
            Phone: entity.Phone,
            UsersId: entity.UsersId
        );
}