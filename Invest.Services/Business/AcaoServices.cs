using System;
using Invest.Entities.Models;
using Invest.Repositories.Contracts;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;
using AutoMapper;
using System.Threading.Tasks;

namespace Invest.Services.Business
{
    public class AcaoServices : IAcaoServices
    {
        private readonly IBaseRepository _repository;
        private readonly IAcaoRepository _acaoRepository;
        private readonly IMapper _mapper;

        public AcaoServices(IAcaoRepository acaoRepository, IBaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _acaoRepository = acaoRepository;
            _mapper = mapper;
        }
        
        public async Task<AcaoVM> Atualizar(AcaoVM model)
        {
            try
            {
                var acao = await _acaoRepository.GetByAcaoId(model.AcaoId);
                if (acao == null) return null;

                _mapper.Map(model, acao);
                _repository.Update<Acao>(acao);
                if (await _repository.SaveChangesAsync())
                {
                    var retorno = await _acaoRepository.GetByAcaoId(acao.AcaoId);
                    return _mapper.Map<AcaoVM>(retorno);
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Deletar(string codigo)
        {
            try
            {
                var acao = await _acaoRepository.GetByAcaoId(codigo);
                if (acao == null) return false;

                _repository.Delete<Acao>(acao);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AcaoVM> Inserir(AcaoVM model)
        {
            try
            {
                var acao = new Acao();
                _mapper.Map(model, acao);
                _repository.Add<Acao>(acao);
                if (await _repository.SaveChangesAsync())
                {
                    var retorno = await _acaoRepository.GetByAcaoId(acao.AcaoId);
                    return _mapper.Map<AcaoVM>(retorno);
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AcaoVM> ListarPorAcaoId(string acaoId)
        {
            try
            {
                var acao = await _acaoRepository.GetByAcaoId(acaoId);
                return _mapper.Map<AcaoVM>(acao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AcaoVM> ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AcaoVM[]> ListarPorRazao(string razao)
        {
            try
            {
                var acao = await _acaoRepository.GetByRazao(razao);
                if (acao.Length == 0) return null;

                return _mapper.Map<AcaoVM[]>(acao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AcaoVM[]> ListarTodos()
        {
            try
            {
                var acao = await _acaoRepository.GetAll();                
                return _mapper.Map<AcaoVM[]>(acao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
