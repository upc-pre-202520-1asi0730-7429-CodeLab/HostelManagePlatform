// Ruta: Subscriptions/Application/Internal/CommandServices/SubscriptionCommandService.cs
using HostelManagerPlatform.API.Shared.Domain.Repositories;
using HostelManagerPlatform.API.Subscriptions.Domain.Model;
using HostelManagerPlatform.API.Subscriptions.Domain.Model.Repositories;

namespace HostelManagerPlatform.API.Subscriptions.Application.Internal.CommandServices
{
    public class SubscriptionCommandService : ISubscriptionCommandService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork; // 

        public SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Subscription> HandleCreateAsync(Subscription subscription)
        {
            
            await _subscriptionRepository.AddAsync(subscription); 
            await _unitOfWork.CompleteAsync(); 
            return subscription;
        }
    }
}