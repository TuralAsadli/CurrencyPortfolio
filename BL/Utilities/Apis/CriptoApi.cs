using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utilities.Apis
{
    public class CriptoApi
    {
        static string url = "https://api.coincap.io/v2/rates/bitcoin";
        public static async Task<string> GetCripto(string value)
        {
            string responseContent;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                responseContent = await response.Content.ReadAsStringAsync();
            }
            
            
            return responseContent;
        }
    }
}
