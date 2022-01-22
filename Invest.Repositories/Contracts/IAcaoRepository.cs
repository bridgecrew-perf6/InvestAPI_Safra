using Invest.Entities;
using System.Threading.Tasks;

namespace Invest.Repositories.Contracts
{
    public interface IAcaoRepository : IBaseRepository<Acao>
    {
        Task<Acao[]> GetAll();
        Task<Acao> GetById(string id);
        Task<Acao[]> GetByRazao(string razao);
    }
}
