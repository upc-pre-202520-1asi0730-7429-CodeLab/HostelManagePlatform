using HostelManagerPlatform.API.Users.Domain.Model.Commands;
using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;

namespace HostelManagerPlatform.API.Users.Domain.Model.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
    Task<bool> Handle(DeleteUserCommand command);
    Task<User?> Handle(UpdateUserCommand command);
}