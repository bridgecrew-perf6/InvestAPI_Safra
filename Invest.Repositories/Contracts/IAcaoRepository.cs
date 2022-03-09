using Invest.Entities.Models;
using System.Threading.Tasks;

namespace Invest.Repositories.Contracts
{
    public interface IAcaoRepository : IBaseRepository
    {
        Task<Acao[]> GetByRazao(string razao);
        Task<Acao> GetByAcaoId(string acaoId);
    }
}
