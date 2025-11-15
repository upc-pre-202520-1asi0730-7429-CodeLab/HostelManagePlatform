using HostelManagerPlatform.API.Hotels.Domain.Model.Commands;
using HostelManagerPlatform.API.Hotels.Interfaces.REST.Resource;

namespace HostelManagerPlatform.API.Hotels.Interfaces.REST.Transform;

/// <summary>
/// Ensambla un CreateHotelSourceCommand a partir de un CreateHotelSourceResource. 
/// </summary>
public static class CreateHotelCommandFromResourceAssembler
{
    /// <summary>
    /// Ensambla un CreateHotelSourceCommand a partir de un CreateHotelSourceResource. 
    /// </summary>
    /// <param name="resource">El recurso CreateHotelSourceResource</param>
    /// <returns>
    /// Un CreateHotelSourceCommand ensamblado a partir del CreateHotelSourceResource
    /// </returns>
    public static CreateHotelCommand ToCommandFromResource(CreateHotelResource resource) =>
        new CreateHotelCommand(
            Id: null, // El ID se establece a null en la creación, lo asigna la BD
            Name: resource.Name,
            Imagen: resource.Imagen,
            Address: resource.Address,
            Phone: resource.Phone,
            UsersId: resource.UsersId
        ); 
}