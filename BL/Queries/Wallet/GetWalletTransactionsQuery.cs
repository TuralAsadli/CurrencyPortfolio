using BL.DTOs.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.Wallet
{
    public class GetWalletTransactionsQuery : IRequest<List<TransactionDTO>>
    {
        public Guid UserId { get; set; }
    }
}
