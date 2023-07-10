using AutoMapper;
using BL.Commands.WalletItems;
using DAL.Entities;

namespace BL.Utilities.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateWalletItemCommand, WalletItem>();
        }
    }
}
