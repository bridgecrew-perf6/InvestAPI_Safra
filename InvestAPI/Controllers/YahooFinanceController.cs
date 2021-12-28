using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvestAPI.Controllers
{
    [Route("api/Cotacao")]
    [ApiController]
    public class YahooFinanceController : Controller
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://yfapi.net/");
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", "0eCCvnCD7I5CHgn9GLZS0atmzEBGsd3O6ZL2CHVy");
                httpClient.DefaultRequestHeaders.Add("accept", "application/json");

                var response = await httpClient.GetAsync("v6/finance/quote?symbols=" + id);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
