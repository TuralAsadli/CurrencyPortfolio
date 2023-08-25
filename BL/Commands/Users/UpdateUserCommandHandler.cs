using AutoMapper;
using BL.Utilities.PasswordHelper;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;

namespace BL.Commands.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user  = _mapper.Map<User>(request);
            PasswordHelper.HashPassword(request.Password,out byte[] hashPassword, out byte[] saltPassword);
            user.HashPassword = hashPassword;
            user.SlatPassword = saltPassword;

            await _repository.Update(user);

            return Unit.Value;
        }
    }
}
