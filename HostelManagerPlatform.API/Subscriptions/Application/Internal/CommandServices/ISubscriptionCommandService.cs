// Ruta: Subscriptions/Application/Internal/CommandServices/ISubscriptionCommandService.cs
using HostelManagerPlatform.API.Subscriptions.Domain.Model;

namespace HostelManagerPlatform.API.Subscriptions.Application.Internal.CommandServices
{
    public interface ISubscriptionCommandService
    {
        Task<Subscription> HandleCreateAsync(Subscription subscription);

    }
}