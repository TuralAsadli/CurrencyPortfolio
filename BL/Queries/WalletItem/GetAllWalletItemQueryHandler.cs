﻿using AutoMapper;
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
    public class GetAllWalletItemQueryHandler : IRequestHandler<GetAllWalletItemQuery, IEnumerable<WalletItemDTO>>
    {
        private IBaseRepository<WalletItem> _repository;
        private IBaseRepository<Wallet> _wallet;
        private IMapper _mapper;

        public GetAllWalletItemQueryHandler(IBaseRepository<WalletItem> repository, IMapper mapper, IBaseRepository<Wallet> wallet)
        {
            _repository = repository;
            _mapper = mapper;
            _wallet = wallet;
        }

        public async Task<IEnumerable<WalletItemDTO>> Handle(GetAllWalletItemQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _repository.GetAll();
            List<WalletItemDTO> walletItemDtos = new List<WalletItemDTO>();
            foreach (var item in wallet)
            {
                var dto = _mapper.Map<WalletItemDTO>(item);
                walletItemDtos.Add(dto);
            }
            return walletItemDtos;
        }
    }
}
