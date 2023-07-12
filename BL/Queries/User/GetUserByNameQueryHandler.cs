using AutoMapper;
using BL.DTOs.UserDTOs;
using DAL.Abstraction;
using MediatR;
using UserEntity = DAL.Entities.User;

namespace BL.Queries.User
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserDTO>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByNameQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetByUserName(request.UserName);
            var userDto = _mapper.Map<UserDTO>(res);
            return userDto;
        }
    }
}
