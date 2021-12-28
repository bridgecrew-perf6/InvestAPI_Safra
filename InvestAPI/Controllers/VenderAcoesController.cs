using Invest.Repositories.Context;
using Invest.Services.Business;
using Invest.Services.Contracts;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InvestAPI.Controllers
{
    [Route("api/VenderAcoes")]
    [ApiController]
    public class VenderAcoesController : Controller
    {
        private readonly DataContext _context;
        protected IOperacaoServices _operacaoServices;

        public VenderAcoesController(DataContext context)
        {
            _context = context;
            _operacaoServices = OperacaoServices.GetOperacaoServices(_context);
        }

        [HttpPost]
        public void VenderAcoes([FromBody] VendaVM venda)
        {
            try
            {
                _operacaoServices.VenderAcoes(venda);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
