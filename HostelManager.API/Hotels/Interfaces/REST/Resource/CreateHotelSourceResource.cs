namespace HostelManager.API.Hotels.Interfaces.REST.Resource;

/// <summary>
/// Representa los datos requeridos para crear un nuevo recurso de HotelSource. 
/// Es el cuerpo (payload) de la solicitud HTTP POST.
/// </summary>
/// <param name="Name">Nombre del hotel.</param>
/// <param name="Imagen">URL o ruta de la imagen del hotel.</param>
/// <param name="Address">Dirección física del hotel.</param>
/// <param name="Phone">Número de teléfono de contacto.</param>
/// <param name="UsersId">ID del administrador/usuario asociado al hotel.</param>
public record CreateHotelSourceResource(
    string Name, 
    string Imagen, 
    string Address, 
    string Phone,
    int? UsersId
);