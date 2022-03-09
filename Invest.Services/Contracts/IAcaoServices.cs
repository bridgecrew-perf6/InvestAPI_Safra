using Invest.Services.ViewModel;
using System.Threading.Tasks;

namespace Invest.Services.Contracts
{
    public interface IAcaoServices
    {
        Task<AcaoVM[]> ListarTodos();
        Task<AcaoVM[]> ListarPorRazao(string razao);
        Task<AcaoVM> ListarPorAcaoId(string acaoId);
        Task<AcaoVM> Inserir(AcaoVM model);
        Task<AcaoVM> Atualizar(AcaoVM model);
        Task<bool> Deletar(string codigo);
    }
}
