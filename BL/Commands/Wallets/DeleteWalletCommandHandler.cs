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
    public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand>
    {
        IWalletRepository _repository;
        IMapper _mapper;

        public DeleteWalletCommandHandler(IWalletRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _repository.FindAsyncById(request.WalletId);
            if (wallet == null) return Unit.Value;

            await _repository.Remove(wallet);

            return Unit.Value;
        }
    }
}
