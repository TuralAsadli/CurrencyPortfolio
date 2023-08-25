using AutoMapper;
using BL.Utilities.PasswordHelper;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;

namespace BL.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            PasswordHelper.HashPassword(request.Password, out byte[] hashPassword, out byte[] saltPassword);

            user.HashPassword = hashPassword;
            user.SlatPassword = saltPassword;

            await _repository.Create(user);

            return Unit.Value;
        }
    }
}
