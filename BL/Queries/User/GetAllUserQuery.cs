using BL.DTOs.User;
using MediatR;

namespace BL.Queries.Users
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDTO>>
    {
    }
}
