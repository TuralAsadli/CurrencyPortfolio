using BL.Commands.WalletItems;
using FluentValidation;

namespace CurrencyApi.Utilites.Validations.WalletItemValidation
{
    public class CreateWalletItemValidator : AbstractValidator<CreateWalletItemCommand>
    {
        public CreateWalletItemValidator()
        {
            RuleFor(walletItem => walletItem.Amount).NotEmpty().WithMessage("Amount can't be empty").GreaterThanOrEqualTo(0).WithMessage("Amount can't be negative");
            RuleFor(walletItem => walletItem.CurrencyName).NotEmpty().WithMessage("Currency Name can't be empty").Length(3, 40).WithMessage("Currency Name must be between 3 and 40 characters.");
            RuleFor(walletItem => walletItem.WalletId).NotEmpty().WithMessage("Chose Wallet");
        }
    }
}
