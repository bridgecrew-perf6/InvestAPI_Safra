using System;
using Invest.Entities;
using Invest.Repositories.Contracts;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Invest.Services.Business
{
    public class OperacaoServices : IOperacaoServices
    {
        private IOperacaoRepository _operacaoRepository;
        public OperacaoServices(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        public async Task<bool> ComprarAcoes(CompraVM compra)
        {
            try
            {
                if (compra != null)
                {
                    var operacao = new Operacao();
                    operacao.TipoOperacao = TipoOperacao.COMPRA;
                    operacao.OperacaoId = compra.OperacaoId;
                    operacao.AcaoId = compra.AcaoId;
                    operacao.PrecoAcao = compra.Preco;
                    operacao.Quantidade = compra.Qtd;
                    operacao.Data = DateTime.Now;
//                    operacao.CustoOperacao = 5.00 + (0.0325 * operacao.PrecoAcao / 100);
                    operacao.Total = (operacao.PrecoAcao * operacao.Quantidade) + (5.00 + (0.0325 * operacao.PrecoAcao / 100));
                    return await _operacaoRepository.Insert(operacao);
                }
                else
                {
                    throw new Exception("Problemas para realizar a transação");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<ListaOperacao> ListarOperacoes()
        {
            try
            {
                return _operacaoRepository.ListarOperacoes();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> VenderAcoes(VendaVM venda)
        {
            try
            {
                if (venda != null)
                {
                    var operacao = new Operacao();
                    operacao.OperacaoId = venda.OperacaoId;
                    operacao.AcaoId = venda.AcaoId;
                    operacao.PrecoAcao = venda.Preco;
                    operacao.Quantidade = venda.Qtd;
                    operacao.TipoOperacao = TipoOperacao.VENDA;
                    operacao.Data = DateTime.Now;
  //                  operacao.CustoOperacao = 5.00 + (0.0325 * operacao.PrecoAcao / 100);
                    operacao.Total = (operacao.PrecoAcao * operacao.Quantidade) + (5.00 + (0.0325 * operacao.PrecoAcao / 100));
                    return await _operacaoRepository.Insert(operacao);
                }
                else
                {
                    throw new Exception("Problemas para realizar a transação");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
