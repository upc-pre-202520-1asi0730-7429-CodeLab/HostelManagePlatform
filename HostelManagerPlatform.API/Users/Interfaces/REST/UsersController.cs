using System.Net.Mime;
using HostelManagerPlatform.API.Resources;
using HostelManagerPlatform.API.Users.Domain.Model.Enums;
using HostelManagerPlatform.API.Users.Domain.Model.Queries;
using HostelManagerPlatform.API.Users.Domain.Model.Services;
using HostelManagerPlatform.API.Users.Interfaces.REST.Resource;
using HostelManagerPlatform.API.Users.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;

namespace HostelManagerPlatform.API.Users.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Users")]
public class UsersController(
    IUserCommandService userCommandService,
    IUserQueryService userQueryService,
    IStringLocalizer<SharedResource> localizer
        ) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a user",
        Description = "Creates a new user",
        OperationId = "CreateUser")]
    [SwaggerResponse(201, "The user was created successfully", typeof(CreateUserResource))]
    [SwaggerResponse(400, "The user was not created successfully")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        try
        {
            var createUserCommand = 
                CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result  = await userCommandService.Handle(createUserCommand);
            if (result == null) return Conflict(localizer["UserDuplicated"].Value);
            return CreatedAtAction("GetUserById", new { id = result.Id },
                UserResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        catch (Exception ex)
        {
            return Conflict(localizer["UserDuplicated"].Value);
        }
    }

    [HttpGet("type/{typeUser}")]
    [SwaggerOperation(
        Summary = "Get all users by type user",
        Description = "Gets all users by type user",
        OperationId = "GetAllUsersByTypeUserQuery")]
    [SwaggerResponse(200, "The users were retrieved successfully", typeof(UserResource))]
    public async Task<ActionResult> GetUserByTypeUserQuery([FromRoute] TypeUser typeUser)
    {
        var getAllUserByTypeUserQuery = new GetAllUserByTypeUserQuery(typeUser);
        var result = await userQueryService.Handle(getAllUserByTypeUserQuery);

        var resources = result.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("email/{email}")]
    [SwaggerOperation(
        Summary = "Get user by email",
        Description = "Get user by email",
        OperationId = "GetUserByEmail")]
    [SwaggerResponse(200, "The users were retrieved successfully", typeof(UserResource))]
    public async Task<ActionResult> GetUserByEmailQuery([FromRoute] string email)
    {
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery);
        if (result == null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get user by id",
        Description = "Get user by id",
        OperationId = "GetUserById")]
    [SwaggerResponse(200, "The user was retrieved successfully", typeof(UserResource))]
    public async Task<ActionResult> GetUserById([FromRoute] int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var result = await userQueryService.Handle(getUserByIdQuery);
        if (result == null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete user",
        Description = "Deletes a user by id",
        OperationId = "DeleteUser")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var resource = new DeleteUserResource(id);
        var command = DeleteUserCommandFromResourceAssembler.ToCommandFromResource(resource);

        var success = await userCommandService.Handle(command);

        if (!success)
            return NotFound(localizer["UserNotFound"].Value);

        return NoContent();
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update user",
        Description = "Updates a user by id",
        OperationId = "UpdateUser")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserResource resource)
    {
        var command = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(id, resource);

        var result = await userCommandService.Handle(command);

        if (result == null) return NotFound(localizer["UserNotFound"].Value);

        return Ok(UserResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all users",
        Description = "Returns the full list of users",
        OperationId = "GetAllUsersQuery")]
    [SwaggerResponse(200, "List of all users", typeof(IEnumerable<UserResource>))]
    public async Task<ActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var result = await userQueryService.Handle(getAllUsersQuery);
        var resources = result.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}