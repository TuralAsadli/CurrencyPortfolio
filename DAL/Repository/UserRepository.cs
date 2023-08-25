using DAL.Abstraction;
using DAL.DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return res;
        }

        public async Task<User> GetByUserName(string userName)
        {
            var res = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return res;
        }

        public new async Task Create(User item)
        {
            item.Wallet = new Wallet();
            await _context.Users.AddAsync(item);
            await Save();
        }
    }
}
