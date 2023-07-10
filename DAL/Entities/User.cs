using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : BaseItem
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] SlatPassword { get; set; }

        public Wallet Wallet { get; set; }

    }
}
