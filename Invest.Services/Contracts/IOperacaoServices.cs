using System.Collections.Generic;
using System.Threading.Tasks;
using Invest.Entities;
using Invest.Services.ViewModel;

namespace Invest.Services.Contracts
{
    public interface IOperacaoServices
    {
        Task<bool> ComprarAcoes(CompraVM operacao);
        Task<bool> VenderAcoes(VendaVM operacao);
        IList<ListaOperacao> ListarOperacoes();
    }
}
