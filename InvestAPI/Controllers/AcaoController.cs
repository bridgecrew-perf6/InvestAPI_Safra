using System;
using System.Threading.Tasks;
using Invest.Entities;
using Invest.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestAPI.Controllers
{
    [Route("api/Acao")]
    [ApiController]
    public class AcaoController : ControllerBase
    {
//        private readonly DataContext _context;
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
                var acoes = await _acaoServices.ListarTodos();
                if (acoes == null) return NotFound("Nenhum evento encontrado");
                return Ok(acoes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar os Eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("codigo/{id}")]
        public async Task<IActionResult> GetByCodigo(string id)
        {
            try
            {
                var acoes = await _acaoServices.ListarPorId(id);
                if (acoes == null) return NotFound("Nenhum evento encontrado");
                return Ok(acoes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar os Eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("razao/{razao}")]
        public async Task<IActionResult> GetByRazao(string razao)
        {
            try
            {
                var acoes = await _acaoServices.ListarPorRazaoSocial(razao);
                if (acoes == null) return NotFound("Nenhum evento encontrado");
                return Ok(acoes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar os Eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Acao acao)
        {
            try
            {
                if (await _acaoServices.Inserir(acao))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Problemas para incluir a Ação");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar os Eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Acao acao)
        {
            try
            {
                if (await _acaoServices.Atualizar(acao))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Problemas para incluir a Ação");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar os Eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            try
            {
                return await _acaoServices.Deletar(id);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
