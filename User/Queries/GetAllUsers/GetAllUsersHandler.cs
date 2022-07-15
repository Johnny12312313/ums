using MediatR;
using WebApplicationDB.Middleware;
using WebApplicationDB.Models;

namespace WebApplicationDB.User.Queries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<Models.User>>
{
    private postgresContext _postgres;
    
    public GetAllUsersHandler(postgresContext postgres)
    {
        _postgres = postgres;
    }

    public async Task<List<Models.User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<Models.User> users = _postgres.Users.Select(x => x).ToList();
        return users;
    }
    
}