using Invest.Services.ViewModel;

namespace Invest.Services.Contracts
{
    public interface IOperacaoServices
    {
        bool ComprarAcoes(CompraVM operacao);
        bool VenderAcoes(VendaVM operacao);
        //IList<ListaOperacao> ListarOperacoes();
    }
}
