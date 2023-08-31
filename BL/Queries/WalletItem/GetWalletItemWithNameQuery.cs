using DAL.Entities;
using MediatR;

namespace BL.Queries.WalletItem
{
    public class GetWalletItemWithNameQuery : IRequest<DAL.Entities.WalletItem>
    {
        public string Name { get; set; }
    }
}
