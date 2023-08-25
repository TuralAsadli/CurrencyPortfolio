using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Transaction
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public float buyPrice { get; set; }
        public float AddedBalance { get; set; }
        public string walletItemName { get; set; }
    }
}
