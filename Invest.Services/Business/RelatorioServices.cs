
namespace Invest.Services.Business
{
    public class RelatorioServices
    {   
        public RelatorioServices()
        {
            
        }

        //public IList<ListaOperacaoVM> ListaDeOperacoes()
        //{
        //    var query = (from l in _context.Set<Operacao>()
        //                 join ac in _context.Set<Acao>() on l.AcaoId equals ac.AcaoId
        //                 select new ListaOperacaoVM
        //                 {
        //                     AcaoId = l.AcaoId,
        //                     RazaoSocial = ac.RazaoSocial,
        //                     TipoOperacao = l.TipoOperacao == TipoOperacao.COMPRA ? "Compra" : "Venda",
        //                     DataOperacao = l.Data,
        //                     Quantidade = l.Quantidade,
        //                     ValorAcao = l.PrecoAcao,
        //                     ValorTotal = l.Total
        //                 });

        //    return query.ToList();
        //}
    }
}
