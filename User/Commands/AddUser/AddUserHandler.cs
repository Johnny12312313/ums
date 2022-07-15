using MediatR;
using WebApplicationDB.Models;

namespace WebApplicationDB.User.Commands.AddUser;

public class AddUserHandler : IRequestHandler<AddUserCommand, List<Models.User>>
{
    public postgresContext _postgres;
    
    public AddUserHandler(postgresContext postgres)
    {
        _postgres = postgres;
    }

    public async Task<List<Models.User>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
         _postgres.Users.AddAsync(request.user);
         _postgres.SaveChanges();
         return _postgres.Users.Select(x => x).ToList();
    }
    
}