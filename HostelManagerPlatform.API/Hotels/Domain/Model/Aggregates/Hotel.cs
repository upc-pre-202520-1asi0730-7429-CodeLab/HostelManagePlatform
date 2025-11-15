using HostelManagerPlatform.API.Hotels.Domain.Model.Commands;

namespace HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;

public partial class Hotel
{
    // Propiedades del Hotel (basadas en tus requerimientos)
    public int? Id { get; } // null por defecto
    public string Name { get; private set; } // '' por defecto
    public string Imagen { get; private set; } // '' por defecto
    public string Address { get; private set; } // '' por defecto
    public string Phone { get; private set; } // '' por defecto
    public int? UsersId { get; private set; } // null por defecto

    /// <summary>
    ///     Constructor protegido para el ORM o la deserialización.
    ///     Inicializa las propiedades con valores por defecto (null o string.Empty).
    /// </summary>
    protected Hotel()
    {
        Id = null;
        Name = string.Empty;
        Imagen = string.Empty;
        Address = string.Empty;
        Phone = string.Empty;
        UsersId = null;
    }

    /// <summary>
    ///     Constructor para el agregado HotelSource.
    /// </summary>
    /// <remarks>
    ///     El constructor es el 'command handler' para el CreateHotelSourceCommand (asumiendo su existencia).
    /// </remarks>
    /// <param name="command">The CreateHotelSourceCommand command</param>
    public Hotel(CreateHotelCommand command)
    {
        // El 'Id' se establece a null en la creación para que lo asigne la persistencia.
        Id = null; 
        Name = command.Name;
        Imagen = command.Imagen;
        Address = command.Address;
        Phone = command.Phone;
        UsersId = command.UsersId;
    }
}