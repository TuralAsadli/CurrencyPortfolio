using AutoMapper;
using DAL.Abstraction;
using DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Commands.Wallets
{
    public class CreateWalletCommand : IRequest
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
