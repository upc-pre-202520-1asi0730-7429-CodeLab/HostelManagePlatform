using HostelManager.API.Hotels.Domain.Model.Aggregates;
using HostelManager.API.Hotels.Domain.Model.Commands;
using HostelManager.API.Hotels.Domain.Model.Repositories;
using HostelManager.API.Hotels.Domain.Model.Services;
using HostelManager.API.Shared.Domain.Repositories; // Asumiendo IUnitOfWork está aquí


namespace HostelManager.API.Hotels.Application.Internal.CommandServices;

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
public class HotelSourceCommandService(IHotelSourceRepository hotelSourceRepository, IUnitOfWork unitOfWork)
    : IHotelSourceCommandService
{
    /// <inheritdoc />
    public async Task<HotelSource?> Handle(CreateHotelSourceCommand command)
    {
        // 1. Crear el nuevo agregado
        var hotelSource = new HotelSource(command);
        
        try
        {
            // 2. Persistir: Llamada corregida a AddAsync()
            // Esto marca la nueva entidad para su inserción.
            await hotelSourceRepository.AddAsync(hotelSource);
            
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

        return hotelSource;
    }
}