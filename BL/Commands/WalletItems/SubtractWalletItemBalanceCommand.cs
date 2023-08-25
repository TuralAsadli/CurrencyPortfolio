using MediatR;

namespace BL.Commands.WalletItems
{
    public class SubtractWalletItemBalanceCommand : IRequest
    {
        public Guid walletItemid { get; set; }

        public float subtractedAmount { get; set; }
    }
}
