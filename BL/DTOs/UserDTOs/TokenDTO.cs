using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.UserDTOs
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
