using MediatR;
using WebApplicationDB.Models;

namespace WebApplicationDB.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<Models.User>
{
    public int Id { get; set; }
}