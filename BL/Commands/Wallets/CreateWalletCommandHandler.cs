using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using DAL.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.Wallets
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand>
    {
        IWalletRepository _repository;
        IMapper _mapper;

        public CreateWalletCommandHandler(IWalletRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
           
            var wallet = _mapper.Map<Wallet>(request);
            await _repository.Create(wallet);
            return Unit.Value;
        }
    }
}
