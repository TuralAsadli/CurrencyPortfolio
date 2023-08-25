using DAL.Abstraction;
using DAL.Entities;
using DAL.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.WalletItems
{
    internal class AddWalletItemBalanceCommandHandler : IRequestHandler<AddWalletItemBalanceCommand>
    {
        private readonly IWalletItemRepository _repository;

        public AddWalletItemBalanceCommandHandler(IWalletItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddWalletItemBalanceCommand request, CancellationToken cancellationToken)
        {
            var walletitem = await _repository.FindByName(request.Name);
            if (walletitem == null) return Unit.Value;

            walletitem.BuyPrice = (walletitem.BuyPrice + request.buyPrice) / 2;

            walletitem.Amount += request.AddedAmount;

            await _repository.Update(walletitem);

            return Unit.Value;
        }
    }
}
