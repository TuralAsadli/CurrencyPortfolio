using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Currency : BaseItem
    {
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public float Price { get; set; }
        public string IconPath { get; set; }

        public IEnumerable<WalletItem> WalletItems { get; set; }
    }
}
