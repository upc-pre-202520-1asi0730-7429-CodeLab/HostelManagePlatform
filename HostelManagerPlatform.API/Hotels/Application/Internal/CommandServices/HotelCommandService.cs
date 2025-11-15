using HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Hotels.Domain.Model.Commands;
using HostelManagerPlatform.API.Hotels.Domain.Model.Repositories;
using HostelManagerPlatform.API.Hotels.Domain.Model.Services;
using HostelManagerPlatform.API.Shared.Domain.Repositories;

namespace HostelManagerPlatform.API.Hotels.Application.Internal.CommandServices;

/// <summary>
///     Servicio de comandos para HotelSource.
/// </summary>
/// <remarks>
///     Esta clase implementa las operaciones básicas para un servicio de comandos de HotelSource.
/// </remarks>
/// <param name="hotelSourceRepository">La instancia de IHotelSourceRepository</param>
/// <param name="unitOfWork">La instancia de IUnitOfWork</param>
/// <see cref="IHotelSourceRepository">IHotelSourceRepository</see>
/// ,
/// <see cref="IUnitOfWork">IUnitOfWork</see>
public class HotelCommandService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
    : IHotelCommandService
{
    /// <inheritdoc />
    public async Task<Hotel?> Handle(CreateHotelCommand command)
    {
        // 1. Crear el nuevo agregado
        var hotel = new Hotel(command);
        
        try
        {
            // 2. Persistir: Llamada corregida a AddAsync()
            // Esto marca la nueva entidad para su inserción.
            await hotelRepository.AddAsync(hotel);
            
            // 3. Compromiso de la Unidad de Trabajo: 
            // Esto ejecuta la inserción (INSERT) en la base de datos.
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            // En caso de error (ej. restricción de base de datos, fallo de conexión)
            // Se retorna null como en el ejemplo original.
            // Es buena práctica registrar (loggear) la excepción 'e' aquí.
            return null;
        }

        return hotel;
    }
}