using HostelManager.API.Hotels.Domain.Model.Commands;
using HostelManager.API.Hotels.Interfaces.REST.Resource;

namespace HostelManager.API.Hotels.Interfaces.REST.Transform;

/// <summary>
/// Ensambla un CreateHotelSourceCommand a partir de un CreateHotelSourceResource. 
/// </summary>
public static class CreateHotelSourceCommandFromResourceAssembler
{
    /// <summary>
    /// Ensambla un CreateHotelSourceCommand a partir de un CreateHotelSourceResource. 
    /// </summary>
    /// <param name="resource">El recurso CreateHotelSourceResource</param>
    /// <returns>
    /// Un CreateHotelSourceCommand ensamblado a partir del CreateHotelSourceResource
    /// </returns>
    public static CreateHotelSourceCommand ToCommandFromResource(CreateHotelSourceResource resource) =>
        new CreateHotelSourceCommand(
            Id: null, // El ID se establece a null en la creación, lo asigna la BD
            Name: resource.Name,
            Imagen: resource.Imagen,
            Address: resource.Address,
            Phone: resource.Phone,
            UsersId: resource.UsersId
        );  
}