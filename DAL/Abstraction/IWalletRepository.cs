using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstraction
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<Wallet> GetWalletByUserIdAsync(Guid Userid);
        Task AddTransaction(Guid guid, Transaction transaction);
    }
}
