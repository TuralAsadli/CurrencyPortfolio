using BL.Utilities.Apis.Responses.Crypto;
using BL.Utilities.Apis.Responses.Stock;
using BL.Utilities.CurrencyApi;

namespace BL.Utilities.Apis
{
    public class ApiManager
    {
        //private string apiKey;
        private string _type;
        private string _currencyName;

        public ApiManager(string type, string currencyName)
        {
            _type = type;
            _currencyName = currencyName;
        }


        public async Task<CryptoApiResponse> GetCripto()
        {
            var res = await CryptoApi.GetCripto(_currencyName);
            return res;

        }

        public async Task<StockApiResponse> GetStock()
        {
            var res = await StockApi.GetStockInfo(_currencyName);
            return res;
        }
    }
}
