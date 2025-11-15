using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Users.Domain.Model.Queries;
using HostelManagerPlatform.API.Users.Domain.Model.Repositories;
using HostelManagerPlatform.API.Users.Domain.Model.Services;

namespace HostelManagerPlatform.API.Users.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByEmailQuery query)
    {
        return await userRepository.FindByEmailAsync(query.Email);
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUserByTypeUserQuery query)
    {
        return await userRepository.FindAllByTypeUserAsync(query.TypeUser);
    }
    
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
}