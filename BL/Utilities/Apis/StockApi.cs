using BL.Utilities.Apis.Responses.Stock;
using Newtonsoft.Json;

namespace BL.Utilities.CurrencyApi
{
    public class StockApi
    {
        private static string url = "https://api.stockdata.org/v1/data/quote?symbols=";
        private static string token = "&api_token=akqeQLgNyK9to6rPnTPasbN8Td18yTSAW5o65Kd3";

        public static async Task<StockApiResponse> GetStockInfo(string stockname)
        {
            StockApiResponse responseBody;
            using (HttpClient http = new HttpClient())
            {
                var response = await http.GetAsync(url + stockname + token);
                responseBody = JsonConvert.DeserializeObject<StockApiResponse>(await response.Content.ReadAsStringAsync());
            }
            return responseBody;
        }


    }
}
