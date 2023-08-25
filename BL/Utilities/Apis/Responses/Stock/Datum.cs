using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Apis.Responses.Stock
{
    public class Datum
    {
        public string ticker { get; set; }
        public string name { get; set; }
        public object exchange_short { get; set; }
        public object exchange_long { get; set; }
        public string mic_code { get; set; }
        public string currency { get; set; }
        public double price { get; set; }
        public double day_high { get; set; }
        public double day_low { get; set; }
        public double day_open { get; set; }

        [JsonProperty("52_week_high")]
        public double _52_week_high { get; set; }

        [JsonProperty("52_week_low")]
        public double _52_week_low { get; set; }
        public object market_cap { get; set; }
        public double previous_close_price { get; set; }
        public DateTime previous_close_price_time { get; set; }
        public double day_change { get; set; }
        public int volume { get; set; }
        public bool is_extended_hours_price { get; set; }
        public DateTime last_trade_time { get; set; }
    }
}
