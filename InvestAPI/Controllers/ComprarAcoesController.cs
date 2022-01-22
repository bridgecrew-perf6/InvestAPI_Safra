using System;
using System.Threading.Tasks;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestAPI.Controllers
{
    [Route("api/ComprarAcoes")]
    [ApiController]
    public class ComprarAcoesController : Controller
    {
        protected IOperacaoServices _operacaoServices;
        public ComprarAcoesController(IOperacaoServices operacaoServices)
        {
            _operacaoServices = operacaoServices;
        }

        [HttpPost]
        public async Task<IActionResult> ComprarAcoes([FromBody] CompraVM compra)
        {
            try
            {
                if (await _operacaoServices.ComprarAcoes(compra))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Problemas para realizar a operação");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar os Eventos. Erro: {ex.Message}");
            }
        }
    }
}
