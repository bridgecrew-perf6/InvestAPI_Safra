using System;
using System.Threading.Tasks;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestAPI.Controllers
{
    [Route("api/VenderAcoes")]
    [ApiController]
    public class VenderAcoesController : Controller
    {
        protected IOperacaoServices _operacaoServices;

        public VenderAcoesController(IOperacaoServices operacaoServices)
        {
            _operacaoServices = operacaoServices;
        }

        [HttpPost]
        public async Task<IActionResult> VenderAcoes([FromBody] VendaVM venda)
        {
            try
            {
                if (_operacaoServices.VenderAcoes(venda))
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
