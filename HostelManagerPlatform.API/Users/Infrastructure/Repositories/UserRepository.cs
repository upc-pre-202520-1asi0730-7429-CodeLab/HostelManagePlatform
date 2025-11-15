using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Configuration;
using HostelManagerPlatform.API.Shared.Infrastructure.Persistence.Repositories;
using HostelManagerPlatform.API.Users.Domain.Model.Enums;
using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Users.Domain.Model.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HostelManagerPlatform.API.Users.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<IEnumerable<User>> FindAllByTypeUserAsync(TypeUser typeUser)
    {
        return await Context.Set<User>().Where(f => f.TypeUser == typeUser).ToListAsync();
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(f => f.Email == email);
    }
}