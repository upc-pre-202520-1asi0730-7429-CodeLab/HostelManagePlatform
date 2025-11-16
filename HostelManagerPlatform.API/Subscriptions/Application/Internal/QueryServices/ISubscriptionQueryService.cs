// Ruta: Subscriptions/Application/Internal/QueryServices/ISubscriptionQueryService.cs
using HostelManagerPlatform.API.Subscriptions.Domain.Model;

namespace HostelManagerPlatform.API.Subscriptions.Application.Internal.QueryServices
{
    public interface ISubscriptionQueryService
    {
        // Definimos dos consultas: Obtener todas y Obtener por ID
        Task<IEnumerable<Subscription>> HandleGetAllAsync();
        Task<Subscription?> HandleGetByIdAsync(int id);
    }
}