using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using DAL.Repository;
using MediatR;

namespace BL.Commands.Wallets
{
    public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand>
    {
        IWalletRepository _repository;
        IMapper _mapper;

        public UpdateWalletCommandHandler(IWalletRepository repository, IMapper mapper)
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
