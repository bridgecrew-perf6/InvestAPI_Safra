using Invest.Entities;
using Invest.Services.ViewModel;

namespace Invest.Services.Contracts
{
    public interface IOperacaoServices : IBaseServices<Operacao>
    {
        bool ComprarAcoes(CompraVM operacao);
        bool VenderAcoes(VendaVM operacao);
    }
}
