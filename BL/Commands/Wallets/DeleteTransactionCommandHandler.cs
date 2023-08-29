using DAL.Abstraction;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.Wallets
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        readonly IBaseRepository<Transaction> _repository;

        public DeleteTransactionCommandHandler(IBaseRepository<Transaction> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var res = await _repository.FindAsyncById(request.Id);
            if (res != null)
            {
                await _repository.Remove(res);
            }

            return Unit.Value;
            
        }
    }
}
