using Invest.Entities;
using Invest.Repositories.Context;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services.Business
{
    public class RelatorioServices : BaseServices<Operacao>
    {   
        public RelatorioServices(DataContext context) : base(context)
        {
            _context = context;
        }

        public static RelatorioServices GetRelatorioServices(DataContext context) { return new RelatorioServices(context); }

        public IList<ListaOperacaoVM> ListaDeOperacoes()
        {
            var query = (from l in _context.Set<Operacao>()
                         join ac in _context.Set<Acao>() on l.AcaoId equals ac.AcaoId
                         select new ListaOperacaoVM
                         {
                             AcaoId = l.AcaoId,
                             RazaoSocial = ac.RazaoSocial,
                             TipoOperacao = l.TipoOperacao == TipoOperacao.COMPRA ? "Compra" : "Venda",
                             DataOperacao = l.Data,
                             Quantidade = l.Quantidade,
                             ValorAcao = l.PrecoAcao,
                             ValorTotal = l.Total
                         });

            return query.ToList();
        }
    }
}
