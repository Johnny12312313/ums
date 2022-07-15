using MediatR;
using WebApplicationDB.Models;

namespace WebApplicationDB.User.Queries.GetUserById;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Models.User>
{
    public postgresContext _postgres;
    
    public GetUserByIdHandler(postgresContext postgres)
    {
        _postgres = postgres;
    }

    public async Task<Models.User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = (from c in _postgres.Users
            where c.Id == request.Id
            select c).First();
        return user;
    }
}