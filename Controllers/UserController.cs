using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDB.Middleware;
using WebApplicationDB.Models;
using WebApplicationDB.User.Commands.AddUser;
using WebApplicationDB.User.Commands.DeleteUser;
using WebApplicationDB.User.Commands.UpdateUser;
using WebApplicationDB.User.Queries.GetAllUsers;
using WebApplicationDB.User.Queries.GetUserById;

namespace WebApplicationDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    
    private readonly IMediator _mediator;
    private UserIdLoggingMiddleware _middleware;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
        
    }
    
    [HttpGet("all")]
    public async Task<List<Models.User>> GetAll()
    {
        
        return await _mediator.Send(new GetAllUsersQuery());

    }
    [HttpGet("{id:int}")]
    public async Task<Models.User> GetUserById([FromRoute]int id)
    {
        return  await _mediator.Send(new GetUserByIdQuery
        {
            Id = id
        });
        

    }
    [HttpPost()]
    public async Task<List<Models.User>> AddUser([FromBody]Models.User user)
    {
        return await _mediator.Send(new AddUserCommand
        {
            user = user
        });


    }
    
    [HttpDelete("DeleteStudent/{id:int}")]
    public async Task<List<Models.User>> DeleteStudent([FromRoute]int id)
    {
        return await _mediator.Send(new DeleteUserCommand()
        {
            Id = id
        });


    }
    [HttpGet("UpdateName/{id:int}")]
    public async Task<List<Models.User>> UpdateUser([FromRoute]int id, [FromQuery]string name)
    {
        return await _mediator.Send(new UpdateUserCommand()
        {
            Id = id,
            name = name
            
        });


    }
}