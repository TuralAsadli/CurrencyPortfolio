using AutoMapper;
using BL.DTOs.UserDTOs;
using DAL.Abstraction;
using UserEntity = DAL.Entities.User;
using MediatR;

namespace BL.Queries.Users
{
    internal class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserDTO>>
    {
        private readonly IBaseRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IBaseRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll(user => user.Wallet);
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var item in users)
            {
                var userDto = _mapper.Map<UserDTO>(item);
                usersDTO.Add(userDto);
            }
            return usersDTO;
        }
    }
}
