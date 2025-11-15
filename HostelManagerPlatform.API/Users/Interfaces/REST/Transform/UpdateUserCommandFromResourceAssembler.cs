using HostelManagerPlatform.API.Users.Domain.Model.Commands;
using HostelManagerPlatform.API.Users.Interfaces.REST.Resource;

namespace HostelManagerPlatform.API.Users.Interfaces.REST.Transform;

public static class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource(int id, UpdateUserResource resource)
        => new UpdateUserCommand(
            id,
            resource.Name,
            resource.Email,
            resource.Password,
            resource.TypeUser,
            resource.SubscriptionId
        );
}