using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstraction
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUserName(string userName);
        Task<User> GetByEmail(string email);
    }
}
