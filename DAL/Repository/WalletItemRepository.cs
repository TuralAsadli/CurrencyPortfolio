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
    public class WalletItemRepository : BaseRepository<WalletItem>, IWalletItemRepository
    {
        private readonly AppDbContext _context;
        public WalletItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WalletItem> FindByName(string name)
        {
            var res  = await _context.WalletItems.FirstOrDefaultAsync(x => x.CurrencyCode == name);
            return res;
        }
    }
}
