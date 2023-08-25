using DAL.Abstraction;
using DAL.DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        AppDbContext _context;
        public WalletRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Wallet> GetWalletByUserIdAsync(Guid userId)
        {
            var res = await _context.Wallets.Include(wallet => wallet.WalletItems).Include(w => w.Transaction).FirstOrDefaultAsync(wallet => wallet.UserId == userId);
            return res;
        }

        public async Task AddTransaction(Guid id, Transaction transaction)
        {
            var res = await FindAsyncById(id, w => w.Transaction);
            res.Transaction.Add(transaction);
            await Update(res);
        }
    }
}
