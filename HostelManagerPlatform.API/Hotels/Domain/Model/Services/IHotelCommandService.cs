using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Hotels.Domain.Model.Commands;

namespace HostelManagerPlatform.API.Hotels.Domain.Model.Services;

public interface IHotelCommandService
{
    /// <summary>
    ///     Maneja el comando de creación de un nuevo HotelSource.
    /// </summary>
    /// <remarks>
    ///     Este método debe encapsular la lógica de negocio para validar el comando, 
    ///     crear la instancia del agregado HotelSource y persistirla a través del repositorio.
    /// </remarks>
    /// <param name="command">CreateHotelSourceCommand command</param>
    /// <returns>La instancia del agregado HotelSource creada, o null si falla.</returns>
    /// <exception cref="Exception">Puede lanzar excepciones si la lógica de negocio falla (ej. validación).</exception>
    Task<Hotel?> Handle(CreateHotelCommand command);
}