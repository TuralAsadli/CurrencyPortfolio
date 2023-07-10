using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.WalletItems
{
    public class DeleteWalletItemCommand : IRequest
    {
        public Guid WalletItemId { get; set; }
    }
}
