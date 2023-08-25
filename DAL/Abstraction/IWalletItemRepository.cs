using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstraction
{
    public interface IWalletItemRepository : IBaseRepository<WalletItem>
    {
        Task<WalletItem> FindByName(string name);
    }
}
