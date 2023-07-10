using CurrencyApi.DTOs.WalletItems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.WalletItems
{
    public class GetWalletItemQuery : IRequest<WalletItemDTO>
    {
        public Guid Id { get; set; }
    }
}
