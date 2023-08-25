using DAL.Abstraction;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.WalletItems
{
    public class SubtractWalletItemBalanceCommandHandler : IRequestHandler<SubtractWalletItemBalanceCommand>
    {
        private readonly IWalletItemRepository _repository;

        public SubtractWalletItemBalanceCommandHandler(IWalletItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SubtractWalletItemBalanceCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.FindAsyncById(request.walletItemid);
            item.Amount = item.Amount - request.subtractedAmount;

            await _repository.Update(item);
            return Unit.Value;
        }
    }
}
