using System.Threading.Tasks;
using Invest.Entities;

namespace Invest.Services.Contracts
{
    public interface IAcaoServices
    {
        Task<Acao[]> ListarTodos();
        Task<Acao> ListarPorId(string id);
        Task<Acao[]> ListarPorRazaoSocial(string razao);
        Task<bool> Inserir(Acao model);
        Task<bool> Atualizar(Acao model);
        Task<bool> Deletar(string id);
    }
}
