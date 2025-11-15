using HostelManagerPlatform.API.Users.Domain.Model.Commands;
using HostelManagerPlatform.API.Users.Interfaces.REST.Resource;

namespace HostelManagerPlatform.API.Users.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(resource.Name, resource.Email, resource.Password, resource.TypeUser, resource.SubscriptionId);
    }
}