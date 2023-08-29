using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.Wallets
{
    public class DeleteTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
