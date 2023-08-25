using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using DAL.Repository;
using MediatR;

namespace BL.Commands.WalletItems
{
    public class UpdateWalletItemCommandHandler : IRequestHandler<UpdateWalletItemCommand>
    {
        IWalletItemRepository _repository;
        IMapper _mapper;

        public UpdateWalletItemCommandHandler(IWalletItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWalletItemCommand request, CancellationToken cancellationToken)
        {
            var walletItem = _mapper.Map<WalletItem>(request);
            await _repository.Update(walletItem);
            return Unit.Value;
        }
    }
}
