using HostelManagerPlatform.API.Users.Domain.Model.Enums;

namespace HostelManagerPlatform.API.Users.Domain.Model.Commands;

public record UpdateUserCommand(
    int UserId,
    string Name,
    string Email,
    string Password,
    TypeUser TypeUser,
    int? SubscriptionId);