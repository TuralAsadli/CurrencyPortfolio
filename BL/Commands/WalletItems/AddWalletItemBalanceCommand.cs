using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.WalletItems
{
    public class AddWalletItemBalanceCommand : IRequest
    {
        public float buyPrice { get; set; }
        public float AddedAmount { get; set; }
        public string Name { get; set; }
        public Guid walletItemId { get; set; }
    }
}
