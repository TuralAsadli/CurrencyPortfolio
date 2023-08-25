using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Transaction : BaseItem
    {
        public DateTime Date { get; set; }
        public float buyPrice { get; set; }
        public float AddedBalance { get; set; }
        public string walletItemName { get; set; }

        public Guid WalletId { get; set; }
        public Wallet Wallet { get; set; }

    }
}
