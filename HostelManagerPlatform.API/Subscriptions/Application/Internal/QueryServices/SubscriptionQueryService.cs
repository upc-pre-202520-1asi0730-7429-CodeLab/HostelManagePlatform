// Ruta: Subscriptions/Application/Internal/QueryServices/SubscriptionQueryService.cs
using HostelManagerPlatform.API.Subscriptions.Domain.Model;
using HostelManagerPlatform.API.Subscriptions.Domain.Model.Repositories;

namespace HostelManagerPlatform.API.Subscriptions.Application.Internal.QueryServices
{
    public class SubscriptionQueryService : ISubscriptionQueryService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionQueryService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<Subscription>> HandleGetAllAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }

        public async Task<Subscription?> HandleGetByIdAsync(int id)
        {
            return await _subscriptionRepository.FindByIdAsync(id);
        }
    }
}