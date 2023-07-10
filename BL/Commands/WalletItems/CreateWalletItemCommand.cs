using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.WalletItems
{
    public class CreateWalletItemCommand : IRequest
    {
        public float BuyPrice { get; set; }
        public float Amount { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string IconPath { get; set; }
        public Guid WalletId { get; set; }
    }
}
