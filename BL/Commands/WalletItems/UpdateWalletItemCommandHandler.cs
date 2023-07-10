using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;

namespace BL.Commands.WalletItems
{
    public class UpdateWalletItemCommandHandler : IRequestHandler<UpdateWalletItemCommand>
    {
        IBaseRepository<WalletItem> _repository;
        IMapper _mapper;

        public UpdateWalletItemCommandHandler(IBaseRepository<WalletItem> repository, IMapper mapper)
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
