using AutoMapper;
using BL.DTOs.Wallet;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;

namespace BL.Queries.Wallets
{
    internal class GetWalletQueryHandler : IRequestHandler<GetWalletQuery, WalletDTO>
    {
        private IBaseRepository<Wallet> _repository;
        private IMapper _mapper;

        public GetWalletQueryHandler(IBaseRepository<Wallet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WalletDTO> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.FindAsyncById(request.Id);
            if (res == null) return null;

            var walletDto = _mapper.Map<WalletDTO>(res);

            return walletDto;
        }
    }
}
