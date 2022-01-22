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
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", "0eCCvnCD7I5CHgn9GLZS0atmzEBGsd3O6ZL2CHVy");
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            var response = await httpClient.GetAsync("v6/finance/quote?symbols=" + acaoId);
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
