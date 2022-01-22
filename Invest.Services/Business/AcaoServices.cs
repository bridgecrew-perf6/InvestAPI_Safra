using System;
using System.Threading.Tasks;
using Invest.Entities;
using Invest.Repositories.Contracts;
using Invest.Services.Contracts;

namespace Invest.Services.Business
{
    public class AcaoServices : IAcaoServices
    {
        protected IAcaoRepository _acaoRepository;
        public AcaoServices(IAcaoRepository acaoRepository)
        {
            _acaoRepository = acaoRepository;
        }

        public async Task<Acao[]> ListarTodos()
        {
            try
            {
                var acoes = await _acaoRepository.GetAll();
                if (acoes == null) return null;

                return acoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Acao> ListarPorId(string id)
        {
            try
            {
                var acao = await _acaoRepository.GetById(id);
                if (acao == null) return null;

                return acao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Acao[]> ListarPorRazaoSocial(string razao)
        {
            try
            {
                var acao = await _acaoRepository.GetByRazao(razao);
                if (acao == null) return null;

                return acao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Inserir(Acao model)
        {
            try
            {
                if (model != null)
                {
                     return await _acaoRepository.Insert(model);
                }
                else
                {
                    throw new Exception("Dados invalidos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Atualizar(Acao model)
        {
            try
            {
                if (model != null)
                {
                    return await _acaoRepository.Update(model); 
                }
                else
                {
                    throw new Exception("Dados invalidos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Deletar(string id)
        {
            try
            {
                var acao = await _acaoRepository.GetById(id);
                if (acao == null) throw new Exception("Ação não localizada");
                return await _acaoRepository.Delete(acao);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
