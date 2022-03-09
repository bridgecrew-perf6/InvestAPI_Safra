using System;
using System.Threading.Tasks;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestAPI.Controllers
{
    [Route("api/Acao")]
    [ApiController]
    public class AcaoController : ControllerBase
    {
        private readonly IAcaoServices _acaoServices;

        public AcaoController(IAcaoServices acaoServices)
        {
            _acaoServices = acaoServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var acao = await _acaoServices.ListarTodos();
                if (acao == null) return NotFound("Nenhum evento encontrado");
                return Ok(acao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar a Ação. Erro: {ex.Message}");
            }
        }

        [HttpGet("Codigo/{acaoId}")]
        public async Task<IActionResult> GetByCodigo(string acaoId)
        {
            try
            {
                var acoes = await _acaoServices.ListarPorAcaoId(acaoId);
                if (acoes == null) return NotFound("Nenhum evento encontrado");
                return Ok(acoes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar a Ação. Erro: {ex.Message}");
            }
        }

        [HttpGet("Razao/{razao}")]
        public async Task<IActionResult> GetByRazao(string razao)
        {
            try
            {
                var acoes = await _acaoServices.ListarPorRazao(razao);
                if (acoes == null) return NotFound("Nenhum evento encontrado");
                return Ok(acoes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar a Ação. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AcaoVM acao)
        {
            try
            {
                var acaoInserida = await _acaoServices.Inserir(acao);
                if (acaoInserida == null) return BadRequest("Erro ao tentar adicionar evento");
                return Ok(acaoInserida);                                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar a Ação. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(AcaoVM acao)
        {
            try
            {
                var acaoAtualizada = await _acaoServices.Atualizar(acao);
                if (acaoAtualizada == null) return BadRequest("Erro ao tentar adicionar evento");
                return Ok(acaoAtualizada);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar a Ação. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await _acaoServices.Deletar(id));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar a Ação. Erro: {ex.Message}");
            }
        }
    }
}
