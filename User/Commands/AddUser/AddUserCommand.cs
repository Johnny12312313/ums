using MediatR;
using WebApplicationDB.Models;

namespace WebApplicationDB.User.Commands.AddUser;

public class AddUserCommand : IRequest<List<Models.User>>
{
    public Models.User user { get; set; }
}