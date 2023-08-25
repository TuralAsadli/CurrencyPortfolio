using BL.DTOs.Wallet;
using MediatR;

namespace BL.Queries.Wallets
{
    public class GetAllWalletQuery : IRequest<IEnumerable<WalletDTO>>
    {
    }
}
