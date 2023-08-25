using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.Wallets
{
    public class AddTransactionCommand : IRequest
    {
        public DateTime Date { get; set; }
        public float buyPrice { get; set; }
        public float AddedBalance { get; set; }
        public string ItemName { get; set; }


        public Guid walletItemId { get; set; }

    }
}
