using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Users.Interfaces.REST.Resource;

namespace HostelManagerPlatform.API.Users.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    => new UserResource(entity.Id, entity.Name, entity.Email, entity.Password, entity.TypeUser, entity.SubscriptionId);
}