using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;

namespace BL.Commands.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private IBaseRepository<User> _repository;
        private IMapper _mapper;

        public DeleteUserCommandHandler(IBaseRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindAsyncById(request.Id);

            if (user == null) return Unit.Value;

            await _repository.Remove(user);

            return Unit.Value;
        }
    }
}
