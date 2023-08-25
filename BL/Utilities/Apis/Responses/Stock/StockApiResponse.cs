using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Apis.Responses.Stock
{
    public class StockApiResponse
    {
        public Meta meta { get; set; }
        public List<Datum> data { get; set; }
    }
}
