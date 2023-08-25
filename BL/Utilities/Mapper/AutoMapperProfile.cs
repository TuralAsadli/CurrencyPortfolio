using AutoMapper;
using BL.Commands.Users;
using BL.Commands.WalletItems;
using BL.Commands.Wallets;
using BL.DTOs.Transaction;
using BL.DTOs.UserDTOs;
using BL.DTOs.Wallet;
using DAL.Entities;

namespace BL.Utilities.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User,CreateUserCommand>();
            CreateMap<CreateUserCommand,User>();
            CreateMap<UserDTO,User>();
            CreateMap<User, UserDTO>();
            CreateMap<CreateUserDTO,CreateUserCommand>();
            CreateMap<CreateUserCommand,CreateUserDTO>();
            CreateMap<CreateUserCommand, UserDTO>();
            CreateMap<UpdateUserCommand,User>();


            CreateMap<CreateWalletItemCommand, WalletItem>();
            CreateMap<UpdateWalletItemCommand, WalletItem>();
            CreateMap<Wallet, WalletDTO>();


            CreateMap<CreateWalletCommand, Wallet>();
            CreateMap<UpdateWalletCommand, Wallet>();
            CreateMap<Wallet, WalletDTO>();

            CreateMap<Transaction, TransactionDTO>();
        }
    }
}
