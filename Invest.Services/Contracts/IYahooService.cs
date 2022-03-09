
using System.Threading.Tasks;

namespace Invest.Services.Contracts
{
    public interface IYahooService
    {
        Task<string> Cotacao(string acaoId);
    }
}
