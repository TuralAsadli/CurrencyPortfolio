using AutoMapper;
using DAL.Abstraction;
using MediatR;
using WalletItem = DAL.Entities.WalletItem;

namespace BL.Commands.WalletItems
{
    public class CreateWalletItemCommandHandler : IRequestHandler<CreateWalletItemCommand>
    {
        IWalletItemRepository _repository;
        IWalletRepository _walletRepository;
        IMapper _mapper;

        public CreateWalletItemCommandHandler(IWalletItemRepository repository,IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateWalletItemCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.FindAsyncById(request.WalletId, x => x.WalletItems);
            var walletItem = _mapper.Map<WalletItem>(request);

            if (wallet.WalletItems.FirstOrDefault(x => x.CurrencyCode == request.CurrencyCode) != null)
            {
                await _repository.Update(walletItem);
                return Unit.Value;
            }

            
            await _repository.Create(walletItem);
            return Unit.Value;
        }
    }
}
