using Invest.Repositories.Context;
using Invest.Services.Business;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestAPI.Controllers
{
    [Route("api/ComprarAcoes")]
    [ApiController]
    public class ComprarAcoesController : Controller
    {
        private readonly DataContext _context;
        protected OperacaoServices _operacaoServices;
        public ComprarAcoesController(DataContext context)
        {
            _context = context;
            _operacaoServices = OperacaoServices.GetOperacaoServices(_context);
        }

        [HttpPost]
        public void ComprarAcoes([FromBody] CompraVM compra)
        {
            _operacaoServices.ComprarAcoes(compra);
        }
    }
}
