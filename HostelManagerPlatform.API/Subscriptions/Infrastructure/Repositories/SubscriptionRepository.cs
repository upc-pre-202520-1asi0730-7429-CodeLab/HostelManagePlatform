// Ruta: Subscriptions/Infrastructure/Repositories/SubscriptionRepository.cs
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Configuration;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Repositories;
using HostelManagerPlatform.API.Subscriptions.Domain.Model;
using HostelManagerPlatform.API.Subscriptions.Domain.Model.Repositories;

namespace HostelManagerPlatform.API.Subscriptions.Infrastructure.Repositories
{

    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext context) : base(context)
        {
        }
      


    }
}