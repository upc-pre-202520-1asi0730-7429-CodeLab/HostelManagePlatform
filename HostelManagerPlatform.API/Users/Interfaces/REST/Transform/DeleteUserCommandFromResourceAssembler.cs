using HostelManagerPlatform.API.Users.Domain.Model.Commands;
using HostelManagerPlatform.API.Users.Interfaces.REST.Resource;

namespace HostelManagerPlatform.API.Users.Interfaces.REST.Transform;

public static class DeleteUserCommandFromResourceAssembler
{
    public static DeleteUserCommand ToCommandFromResource(DeleteUserResource resource)
        => new DeleteUserCommand(resource.UserId);
}