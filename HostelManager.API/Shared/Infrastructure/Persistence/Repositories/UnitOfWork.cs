using HostelManager.API.Shared.Domain.Repositories;
using HostelManager.API.Shared.Infrastructure.Persistence.Configuration;

namespace HostelManager.API.Shared.Infrastructure.Persistence.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
   
}