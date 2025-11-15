using HostelManagerPlatform.API.Users.Domain.Model.Commands;
using HostelManagerPlatform.API.Users.Domain.Model.Enums;

namespace HostelManagerPlatform.API.Users.Domain.Model.Aggregates;

public partial class User
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public TypeUser TypeUser { get; private set; }
    public int? SubscriptionId { get; private set; }

    protected User()
    {
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        TypeUser = TypeUser.Host; 
        SubscriptionId = null;
    }

    public User(CreateUserCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Password = command.Password;
        TypeUser = command.TypeUser;
        SubscriptionId = command.SubscriptionId;
    }
    
    public void Update(UpdateUserCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Password = command.Password;
        TypeUser = command.TypeUser;
        SubscriptionId = command.SubscriptionId;
    }
}