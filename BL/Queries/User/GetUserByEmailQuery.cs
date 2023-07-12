using BL.DTOs.UserDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.User
{
    public class GetUserByEmailQuery : IRequest<UserDTO>
    {
        public string Email { get; set; }
    }
}
