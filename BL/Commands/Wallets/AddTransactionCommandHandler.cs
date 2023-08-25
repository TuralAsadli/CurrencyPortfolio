using DAL.Abstraction;
using MediatR;
using DAL.Entities;
namespace BL.Commands.Wallets
{
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand>
    {
        readonly IWalletRepository _repository;
        readonly IWalletItemRepository _walletItemRepository;
        readonly IBaseRepository<Transaction> _transactionRepository;

        public AddTransactionCommandHandler(IWalletRepository repository, IWalletItemRepository walletRepository, IBaseRepository<Transaction> transactionRepository)
        {
            _repository = repository;
            _walletItemRepository = walletRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var res = await _walletItemRepository.FindByName(request.ItemName);
            await _transactionRepository.Create(new Transaction()
            {
                walletItemName = res.CurrencyName,
                AddedBalance = request.AddedBalance,
                WalletId = res.WalletId,
                buyPrice = request.buyPrice,
                Date = request.Date,
            });
            

            return Unit.Value;
        }
    }
}
