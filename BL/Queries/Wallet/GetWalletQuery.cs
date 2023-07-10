using BL.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.Wallets
{
    public class GetWalletQuery : IRequest<WalletDTO>
    {
        public Guid Id { get; set; }
    }
}
