using BL.Utilities.Apis;
using BL.Utilities.Apis.Responses.Crypto;
using BL.Utilities.Apis.Responses.Stock;
using BL.Utilities.CurrencyApi;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyPortfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
       

        private readonly ILogger<CryptoController> _logger;

        public CryptoController(ILogger<CryptoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetStock")]
        public async Task<StockApiResponse> GetStock(string value)
        {
            var res = await StockApi.GetStockInfo(value);
            return res;
        }

        [HttpGet("GetCryptoRate")]
        public async Task<CryptoApiResponse> GetCryproRate(string value)
        {
            var response = await CryptoApi.GetCripto(value);

            return response;
        }

        [HttpGet("GetCryptoList")]
        public async Task<CryptoList> GetCryptoList()
        {
            var response = await CryptoApi.GetCryptoList();
            return response;
        }
    }
}