using HostelManagerPlatform.API.Users.Domain.Model.Enums;

namespace HostelManagerPlatform.API.Users.Domain.Model.Commands;

public record CreateUserCommand(
    string Name,
    string Email,
    string Password,
    TypeUser TypeUser,
    int? SubscriptionId);