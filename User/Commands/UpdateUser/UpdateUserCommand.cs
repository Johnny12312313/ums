using MediatR;

namespace WebApplicationDB.User.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<List<Models.User>>
{
    public int Id { get; set; }
    public string name { get; set; }
}