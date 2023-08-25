using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Calculators.CalculatorsDtos
{
    public class RecomendationListDTO
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public double changePercent24Hr { get; set; }
        public double priceUsd { get; set; }
    }
}
