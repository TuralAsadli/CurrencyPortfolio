using AutoMapper;
using BL.DTOs.User;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries.Users
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDTO>
    {
        private readonly IBaseRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IBaseRepository<User> repository, IMapper mapper)
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
