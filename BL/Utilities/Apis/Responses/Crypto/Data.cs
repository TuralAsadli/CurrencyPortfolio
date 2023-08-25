using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Apis.Responses.Crypto
{
    public class Data
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string currencySymbol { get; set; }
        public string type { get; set; }
        public string rateUsd { get; set; }
    }
}
