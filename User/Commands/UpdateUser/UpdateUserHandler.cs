using MediatR;
using WebApplicationDB.Exception;
using WebApplicationDB.Models;
using WebApplicationDB.User.Queries.GetAllUsers;

namespace WebApplicationDB.User.Commands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, List<Models.User>>
{
    private postgresContext _postgres;
    
    public UpdateUserHandler(postgresContext postgres)
    {
        _postgres = postgres;
    }

    public async Task<List<Models.User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = _postgres.Users.Where(u => u.Id == request.Id)
            .FirstOrDefault<Models.User>();
        if (existingUser != null)
        {
            existingUser.Name = request.name;
            return _postgres.Users.ToList();
        }
        else
        {
            throw new UserNotFound("User not found with this id");
        }
    }
}