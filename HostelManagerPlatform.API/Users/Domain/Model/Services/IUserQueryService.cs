using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Users.Domain.Model.Queries;

namespace HostelManagerPlatform.API.Users.Domain.Model.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByEmailQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUserByTypeUserQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}