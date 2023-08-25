using BL.Commands.WalletItems;
using FluentValidation;

namespace CurrencyPortfolio.Utilites.Validators.Wallet
{
    public class DeleteWalletItemCommandValidator : AbstractValidator<DeleteWalletItemCommand>
    {
        public DeleteWalletItemCommandValidator()
        {
            RuleFor(item => item.WalletItemId).NotEmpty().WithErrorCode("you sendempty object");
        }
    }
}
