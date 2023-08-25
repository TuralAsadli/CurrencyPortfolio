using BL.Utilities.Apis.Responses.Stock;
using BL.Utilities.CurrencyApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        [HttpGet(Name = "GetStock")]
        public async Task<StockApiResponse> Get(string value)
        {
            var res = await StockApi.GetStockInfo(value);
            return res;
        }
    }
}
