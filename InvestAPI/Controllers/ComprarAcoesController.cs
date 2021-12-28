using Invest.Repositories.Context;
using Invest.Services.Business;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InvestAPI.Controllers
{
    [Route("api/ComprarAcoes")]
    [ApiController]
    public class ComprarAcoesController : Controller
    {
        private readonly DataContext _context;
        protected IOperacaoServices _operacaoServices;
        public ComprarAcoesController(DataContext context)
        {
            _context = context;
            _operacaoServices = OperacaoServices.GetOperacaoServices(_context);
        }

        [HttpPost]
        public void ComprarAcoes([FromBody] CompraVM compra)
        {
            try
            {
                _operacaoServices.ComprarAcoes(compra);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
