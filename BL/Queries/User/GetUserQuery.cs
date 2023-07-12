using BL.DTOs.UserDTOs;
using MediatR;

namespace BL.Queries.Users
{
    public class GetUserQuery : IRequest<UserDTO>
    {
        public Guid Id { get; set; }
    }
}
