using BL.DTOs.UserDTOs;
using MediatR;

namespace BL.Queries.User
{
    public class GetUserByNameQuery : IRequest<UserDTO>
    {
        public string UserName { get; set; }
    }
}
