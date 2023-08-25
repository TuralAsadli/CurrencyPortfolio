using BL.Utilities.Apis.Responses.Crypto;
using Newtonsoft.Json;

namespace BL.Utilities.Apis
{
    public class CryptoApi
    {
        static string domain = "https://api.coincap.io/v2/";
        public static async Task<CryptoApiResponse> GetCripto(string value)
        {
            string url = "https://api.coincap.io/v2/rates/bitcoin";
            CryptoApiResponse responseContent;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                responseContent = JsonConvert.DeserializeObject<CryptoApiResponse>(await response.Content.ReadAsStringAsync());
            }


            return responseContent;
        }

        public static async Task<CryptoList> GetCryptoList()
        {
            string url = domain + "assets";
            CryptoList responseContent = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    responseContent = JsonConvert.DeserializeObject<CryptoList>(await response.Content.ReadAsStringAsync());
                }
            }

            return responseContent;
        }
    }
}
