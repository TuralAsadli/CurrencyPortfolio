using AutoMapper;
using BL.DTOs.UserDTOs;
using DAL.Abstraction;
using MediatR;
using UserEntity = DAL.Entities.User;

namespace BL.Queries.Users
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDTO>
    {
        private readonly IBaseRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IBaseRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindAsyncById(request.Id);
            if (user == null) return null;
            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }
    }
}
