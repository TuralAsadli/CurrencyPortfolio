using AutoMapper;
using BL.DTOs.UserDTOs;
using DAL.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.User
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDTO>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetByEmail(request.Email);
            var userDTO = _mapper.Map<UserDTO>(res);
            return userDTO;
        }
    }
}
