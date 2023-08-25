using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class WalletItem : BaseItem
    {
        public float BuyPrice { get; set; }
        public float Amount { get; set; }
        public string Type { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string IconPath { get; set; }
        public Guid WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
