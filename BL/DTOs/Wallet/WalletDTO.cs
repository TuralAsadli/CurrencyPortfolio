using BL.DTOs.Transaction;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Wallet
{
    public class WalletDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public IEnumerable<WalletItem> WalletItems { get; set; }
        public IEnumerable<TransactionDTO> Transaction { get; set; }
    }
}
