using BL.DTOs.Wallet;
using BL.Utilities.Apis;
using BL.Utilities.Apis.Responses.Crypto;
using BL.Utilities.Calculators.CalculatorsDtos;
using System.Globalization;

namespace BL.Utilities.Calculetors
{
    public class UserStatisticsCalculator
    {
        public static async Task<MainStatisticsDTO> GetMainStatistics(WalletDTO wallet)
        {
            float fullBalance = 0f;
            float recivedBalance = 0f;
            string bestAssetName = null;
            float bestScoreInPercentages = 0f;

            foreach (var item in wallet.WalletItems)
            {
                var crypto = await CryptoApi.GetCripto(item.CurrencyCode);

                fullBalance += float.Parse(crypto.data.rateUsd, CultureInfo.InvariantCulture.NumberFormat) * item.Amount;
                recivedBalance += item.BuyPrice * item.Amount;

                if (bestAssetName == null || bestScoreInPercentages < (fullBalance - recivedBalance) / fullBalance)
                {
                    bestAssetName = item.CurrencyCode;
                    bestScoreInPercentages = (fullBalance / recivedBalance) * 100;
                }
            }

            float profit = fullBalance - recivedBalance;
            float profitInPercentages = fullBalance / recivedBalance * 100;

            return new MainStatisticsDTO() { FullBalance = fullBalance, Profit = profit, RecivedBalance = recivedBalance, BestAssetName = bestAssetName, BestScoreInPercentages = bestScoreInPercentages, ProfitInPercentages = profitInPercentages };
        }


        public static async Task<List<RecomendationListDTO>> GetRecomenddationsList()
        {
            var list = await CryptoApi.GetCryptoList();
            if (list == null)
            {
                return null;
            }
            List<RecomendationListDTO> result = new List<RecomendationListDTO>();
            foreach (var item in list.data)
            {
                RecomendationListDTO recomendationListDTO = new RecomendationListDTO();

                recomendationListDTO.name = item.name;
                recomendationListDTO.priceUsd = double.Parse(item.priceUsd, System.Globalization.CultureInfo.InvariantCulture);
                recomendationListDTO.changePercent24Hr = double.Parse(item.changePercent24Hr, System.Globalization.CultureInfo.InvariantCulture);
                recomendationListDTO.symbol = item.symbol;
                
                result.Add(recomendationListDTO);
            }
            return result.OrderByDescending(x => x.changePercent24Hr).ToList();
        }
    }
}
