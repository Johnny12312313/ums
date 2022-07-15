using MediatR;
using WebApplicationDB.Models;

namespace WebApplicationDB.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<List<Models.User>>
{
    public int Id { get; set; }
}