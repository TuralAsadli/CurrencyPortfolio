using AutoMapper;
using CurrencyApi.DTOs.WalletItems;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.WalletItems
{
    public class GetWalletItemQueryHandler : IRequestHandler<GetWalletItemQuery, WalletItemDTO>
    {
        private readonly IWalletItemRepository _repository;
        private readonly IMapper _mapper;

        public GetWalletItemQueryHandler(IWalletItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WalletItemDTO> Handle(GetWalletItemQuery request, CancellationToken cancellationToken)
        {
            var walletItem = await _repository.FindAsyncById(request.Id);
            if (walletItem == null) return null;

            var walletItemDto = _mapper.Map<WalletItemDTO>(walletItem);
            return walletItemDto;
        }
    }
}
