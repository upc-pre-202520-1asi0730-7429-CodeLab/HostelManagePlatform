using HostelManagerPlatform.API.Shared.Domain.Repositories;
using HostelManagerPlatform.API.Users.Domain.Model.Commands;
using HostelManagerPlatform.API.Users.Domain.Model.Aggregates;
using HostelManagerPlatform.API.Users.Domain.Model.Repositories;
using HostelManagerPlatform.API.Users.Domain.Model.Services;

namespace HostelManagerPlatform.API.Users.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, 
    IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var existingUser  = await userRepository.FindByEmailAsync(command.Email);
        
        if (existingUser  != null)
            throw new ArgumentException($"User with email {command.Email} already exists");
        
        var user = new User(command);

        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return user;
    }
    
    public async Task<bool> Handle(DeleteUserCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null) return false;

        try
        {
            userRepository.Remove(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return true;
    }
    
    public async Task<User?> Handle(UpdateUserCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null) return null;
        
        try
        {
            user.Update(command);
            userRepository.Update(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return user;
    }
}