using BL.DTOs.UserDTOs;
using MediatR;

namespace BL.Queries.Users
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDTO>>
    {
    }
}
