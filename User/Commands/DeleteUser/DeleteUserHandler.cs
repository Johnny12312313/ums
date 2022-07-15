using MediatR;
using WebApplicationDB.Exception;
using WebApplicationDB.Models;
using WebApplicationDB.User.Commands.DeleteUser;
using WebApplicationDB.User.Queries.GetUserById;

namespace WebApplicationDB.User.Commands.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, List<Models.User>>
{
    public postgresContext _postgres;
    
    public DeleteUserHandler(postgresContext postgres)
    {
        _postgres = postgres;
    }

    public async Task<List<Models.User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        for (int i = 0; i < _postgres.Users.ToList().Count; i++)
        {
            if (_postgres.Users.ToList()[i].Id == request.Id)
            {
                _postgres.Users.Remove(_postgres.Users.ToList()[i]);
                _postgres.SaveChanges();
                return _postgres.Users.Select(x => x).ToList();
            }
        }
        throw new UserNotFound("User not found with this id");

        return null;
    }
    
}