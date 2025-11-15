using HostelManagerPlatform.API.Users.Domain.Model.Enums;

namespace HostelManagerPlatform.API.Users.Interfaces.REST.Resource;

public record CreateUserResource(string Name, string Email, string Password, TypeUser TypeUser, int? SubscriptionId);