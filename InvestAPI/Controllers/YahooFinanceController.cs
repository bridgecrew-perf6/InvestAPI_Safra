using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Invest.Entities;
using Invest.Services.Contracts;

namespace InvestAPI.Controllers
{
    [Route("api/Cotacao")]
    [ApiController]
    public class YahooFinanceController : Controller
    {
        protected IYahooService _yahooService;

        public YahooFinanceController(IYahooService yahooService)
        {
            _yahooService = yahooService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _yahooService.Cotacao(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
