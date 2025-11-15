using HostelManagerPlatform.API.Shared.Domain.Repositories;
using HostelManagerPlatform.API.Users.Domain.Model.Enums;
using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;

namespace HostelManagerPlatform.API.Users.Domain.Model.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
    Task<IEnumerable<User>> FindAllByTypeUserAsync(TypeUser typeUser);
}