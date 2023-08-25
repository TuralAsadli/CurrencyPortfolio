using BL.Utilities.Apis.Responses.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Apis.Responses.Crypto
{
    public class CryptoList
    {
        public List<CryptoItem> data { get; set; }
        public long timestamp { get; set; }
    }
}
