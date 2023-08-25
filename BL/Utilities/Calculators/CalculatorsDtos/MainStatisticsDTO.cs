using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Calculators.CalculatorsDtos
{
    public class MainStatisticsDTO
    {
        public float FullBalance { get; set; }
        public float RecivedBalance { get; set; }
        public float Profit { get; set; }
        public float ProfitInPercentages { get; set; }
        public string BestAssetName { get; set; }
        public float BestScoreInPercentages { get; set; }
    }
}
