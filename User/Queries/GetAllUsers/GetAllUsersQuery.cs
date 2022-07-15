using MediatR;
using WebApplicationDB.Models;

namespace WebApplicationDB.User.Queries.GetAllUsers;

public class GetAllUsersQuery: IRequest<List<Models.User>>
{
    
}