using Invest.Entities.Models;
using System.Threading.Tasks;

namespace Invest.Repositories.Contracts
{
    public interface IOperacaoRepository : IBaseRepository
    {
        Task<Operacao[]> GetByAcaoId(string acaoId);
    }
}
