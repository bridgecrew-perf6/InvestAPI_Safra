using System;
using System.Net.Http;
using System.Threading.Tasks;
using Invest.Services.Contracts;

namespace Invest.Services.Business
{
    public class YahooService : IYahooService
    {
        public async Task<string> Cotacao(string acaoId)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://yfapi.net/");
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", "f17P7wo9pU6CixpZkBTNwbYLRxyXdDy27VsryMS2");
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            var response = await httpClient.GetAsync("v6/finance/quote?symbols=" + acaoId);
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
