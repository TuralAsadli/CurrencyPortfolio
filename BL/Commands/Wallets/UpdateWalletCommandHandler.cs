using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;

namespace BL.Commands.Wallets
{
    public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand>
    {
        IBaseRepository<Wallet> _repository;
        IMapper _mapper;

        public UpdateWalletCommandHandler(IBaseRepository<Wallet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = _mapper.Map<Wallet>(request);
            await _repository.Update(wallet);

            return Unit.Value;
        }
    }
}
