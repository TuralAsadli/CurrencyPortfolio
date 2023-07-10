using AutoMapper;
using DAL.Abstraction;
using MediatR;
using WalletItem = DAL.Entities.WalletItem;

namespace BL.Commands.WalletItems
{
    public class CreateWalletItemCommandHandler : IRequestHandler<CreateWalletItemCommand>
    {
        IBaseRepository<WalletItem> _repository;
        IMapper _mapper;

        public CreateWalletItemCommandHandler(IBaseRepository<WalletItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateWalletItemCommand request, CancellationToken cancellationToken)
        {
            var walletItem = _mapper.Map<WalletItem>(request);
            await _repository.Create(walletItem);
            return Unit.Value;
        }
    }
}
