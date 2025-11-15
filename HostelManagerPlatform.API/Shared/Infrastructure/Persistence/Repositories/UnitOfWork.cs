using HostelManagerPlatform.API.Shared.Domain.Repositories;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Configuration;

namespace HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}