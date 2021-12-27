using Invest.Entities;
using Invest.Repositories;
using Invest.Repositories.Context;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;

namespace Invest.Services.Business
{
    public class OperacaoServices : BaseServices<Operacao>, IOperacaoServices
    {
        //protected OperacaoRepository _operacaoRepository;
        public OperacaoServices(DataContext context) : base(context)
        {
            _context = context;
            //_operacaoRepository = OperacaoRepository.GetOperacaoRepository(_context);
        }
        public static OperacaoServices GetOperacaoServices(DataContext context) { return new OperacaoServices(context); }
        public bool ComprarAcoes(CompraVM compra)
        {
            if (compra != null)
            {
                var operacao = new Operacao();
                operacao.TipoOperacao = TipoOperacao.COMPRA;
                operacao.OperacaoId = compra.OperacaoId;
                operacao.AcaoId = compra.AcaoId;
                operacao.PrecoAcao = compra.Preco;
                operacao.Quantidade = compra.Qtd;
                _context.Operacoes.Add(operacao);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VenderAcoes(VendaVM venda)
        {
            if(venda !=null)
            {
                var operacao = new Operacao();
                operacao.OperacaoId = venda.OperacaoId;
                operacao.AcaoId = venda.AcaoId;
                operacao.PrecoAcao = venda.Preco;
                operacao.Quantidade = venda.Qtd;
                operacao.TipoOperacao = TipoOperacao.VENDA;
                _context.Operacoes.Add(operacao);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
