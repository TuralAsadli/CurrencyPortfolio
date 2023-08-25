using AutoMapper;
using BL.Commands.Users;
using BL.DTOs.UserDTOs;

namespace CurrencyPortfolio.Utilites.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserCommand, CreateUserDTO>();
            CreateMap<CreateUserCommand, UserDTO>();
        }
    }
}
