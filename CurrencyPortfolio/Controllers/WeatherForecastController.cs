using BL.Utilities.Apis;
using BL.Utilities.CurrencyApi;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyPortfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetStock")]
        public async Task<string> GetStock(string value)
        {
            var res = await StockApi.GetStockInfo(value);
            return res;
        }

        [HttpGet("GetCryptoRate")]
        public async Task<string> GetCryproRate(string value)
        {
            var response = await CriptoApi.GetCripto(value);

            return response;
        }
    }
}