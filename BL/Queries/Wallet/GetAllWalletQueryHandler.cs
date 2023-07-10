using AutoMapper;
using BL.DTOs.Wallet;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.Wallets
{
    internal class GetAllWalletQueryHandler : IRequestHandler<GetAllWalletQuery, IEnumerable<WalletDTO>>
    {
        private readonly IBaseRepository<Wallet> _repository;
        private readonly IMapper _mapper;

        public GetAllWalletQueryHandler(IBaseRepository<Wallet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WalletDTO>> Handle(GetAllWalletQuery request, CancellationToken cancellationToken)
        {
            var wallets = await _repository.GetAll(w => w.WalletItems, wallets => wallets.User);

            List<WalletDTO> walletDtoList = new List<WalletDTO>();
            foreach (var item in wallets)
            {
                var walletDto = _mapper.Map<WalletDTO>(item);
                walletDtoList.Add(walletDto);
            }

            return walletDtoList;
        }
    }
}
