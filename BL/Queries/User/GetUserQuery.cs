using BL.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.Users
{
    public class GetUserQuery : IRequest<UserDTO>
    {
        public Guid Id { get; set; }
    }
}
