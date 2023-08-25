using AutoMapper;
using BL.DTOs.Transaction;
using DAL.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.Wallet
{
    public class GetWalletTransactionsQueryHandler : IRequestHandler<GetWalletTransactionsQuery, List<TransactionDTO>>
    {
        readonly IWalletRepository _walletRepository;
        private IMapper _mapper;

        public GetWalletTransactionsQueryHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionDTO>> Handle(GetWalletTransactionsQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletByUserIdAsync(request.UserId);
            List<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
            foreach (var item in wallet.Transaction)
            {
                var transaction =  _mapper.Map<TransactionDTO>(item);
                transaction.Date = item.Date.ToString("dd.MM.yyyy");
                transactionDTOs.Add(transaction);
            }
            
            return transactionDTOs;
            
        }
    }
}
