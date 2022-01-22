using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invest.Entities;
using Invest.Repositories.Context;
using Invest.Repositories.Contracts;

namespace Invest.Repositories
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private readonly DataContext _context;

        public OperacaoRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<bool> Insert(Operacao entity)
        {
            _context.Add<Operacao>(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(Operacao entity)
        {
            _context.Update<Operacao>(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> Delete(Operacao entity)
        {
            _context.Remove<Operacao>(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }
        public IList<ListaOperacao> ListarOperacoes()
        {
            var query = (from l in _context.Set<Operacao>()
                                                join ac in _context.Set<Acao>() on l.AcaoId equals ac.AcaoId
                                                 select new ListaOperacao()
                                                 {
                                                     AcaoId = l.AcaoId,
                                                     RazaoSocial = ac.RazaoSocial,
                                                     TipoOperacao = l.TipoOperacao == TipoOperacao.COMPRA ? "Compra" : "Venda",
                                                     DataOperacao = l.Data,
                                                     Quantidade = l.Quantidade,
                                                     ValorAcao = l.PrecoAcao,
                                                     ValorTotal = l.Total
                                                 }).ToList();

            return query;
        }
    }
}
