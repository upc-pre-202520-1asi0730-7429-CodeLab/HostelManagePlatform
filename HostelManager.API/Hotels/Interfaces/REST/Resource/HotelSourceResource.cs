namespace HostelManager.API.Hotels.Interfaces.REST.Resource;

/// <summary>
/// Representa los datos proporcionados por el servidor sobre un recurso de HotelSource. 
/// Es la estructura de datos que se retorna en las respuestas HTTP.
/// </summary>
/// <param name="Id">El identificador único generado por el servidor.</param>
/// <param name="Name">Nombre del hotel.</param>
/// <param name="Imagen">URL o ruta de la imagen del hotel.</param>
/// <param name="Address">Dirección física del hotel.</param>
/// <param name="Phone">Número de teléfono de contacto.</param>
/// <param name="UsersId">ID del administrador/usuario asociado al hotel.</param>
public record HotelSourceResource(
    int Id, 
    string Name, 
    string Imagen, 
    string Address, 
    string Phone,
    int? UsersId
);