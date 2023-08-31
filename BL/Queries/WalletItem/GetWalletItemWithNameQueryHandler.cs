using DAL.Abstraction;
using MediatR;

namespace BL.Queries.WalletItem
{
    public class GetWalletItemWithNameQueryHandler : IRequestHandler<GetWalletItemWithNameQuery, DAL.Entities.WalletItem>
    {
        private readonly IWalletItemRepository _repository;

        public GetWalletItemWithNameQueryHandler(IWalletItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<DAL.Entities.WalletItem> Handle(GetWalletItemWithNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FindByName(request.Name);
        }
    }
}
