using BL.Commands.WalletItems;
using DAL.Entities;
using FluentValidation;
using System.Linq;

namespace CurrencyApi.Utilites.Validations.WalletItemValidation
{
    public class UpdateWalletItemValidation : AbstractValidator<UpdateWalletItemCommand>
    {
        public UpdateWalletItemValidation()
        {
            RuleFor(walletItem => walletItem.Id).NotEmpty().WithMessage("Id can't be empty");
            RuleFor(walletItem => walletItem.Amount).NotEmpty().WithMessage("Amount can't be empty").GreaterThanOrEqualTo(0).WithMessage("Amount can't be negative");
            RuleFor(walletItem => walletItem.CurrencyName).NotEmpty().WithMessage("Currency Name can't be empty").Length(3, 40).WithMessage("Currency Name must be between 3 and 40 characters.");
            RuleFor(walletItem => walletItem.WalletId).NotEmpty().WithMessage("Chose Wallet");
        }
    }
}
