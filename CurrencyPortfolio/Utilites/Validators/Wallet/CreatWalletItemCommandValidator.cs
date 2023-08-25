using BL.Commands.WalletItems;
using FluentValidation;

namespace CurrencyPortfolio.Utilites.Validators.Wallet
{

    public class CreatWalletItemCommandValidator : AbstractValidator<CreateWalletItemCommand>
    {
        public CreatWalletItemCommandValidator()
        {
            RuleFor(walletItem => walletItem.BuyPrice).GreaterThan(0).WithMessage("Buy Price can't be negative");
            RuleFor(walletItem => walletItem.CurrencyCode).NotEmpty().WithMessage("Currency Code can't be empty");
            RuleFor(walletItem => walletItem.CurrencyName).NotEmpty().WithMessage("Currency name can't be mepty");
            RuleFor(walletItem => walletItem.IconPath).NotEmpty().WithMessage("Icon can't be mepty");
            RuleFor(walletItem => walletItem.Amount).GreaterThanOrEqualTo(0).WithMessage("Amount can't be negative");
            RuleFor(walletItem => walletItem.WalletId).NotEmpty().WithMessage("Wallet Id can't be empty");
        }
    }
}
