using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;

namespace BL.Commands.WalletItems
{
    public class DeleteWalletItemCommandHandler : IRequestHandler<DeleteWalletItemCommand>
    {
        IWalletItemRepository _repository;
        IMapper _mapper;

        public DeleteWalletItemCommandHandler(IMapper mapper, IWalletItemRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteWalletItemCommand request, CancellationToken cancellationToken)
        {
            var walletItem = await _repository.FindAsyncById(request.WalletItemId);
            if (walletItem == null) return Unit.Value;

            await _repository.Remove(walletItem);
            return Unit.Value;
        }
    }
}
