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
    [Route("api/ListaOperacao")]
    [ApiController]
    public class ListaOperacaoController : Controller
    {
        private readonly DataContext _context;
        protected RelatorioServices _relatorioServices;

        public ListaOperacaoController(DataContext context)
        {
            _context = context;
            _relatorioServices = RelatorioServices.GetRelatorioServices(_context);
        }

        [HttpGet]
        public IList<ListaOperacaoVM> ListarOperacoes()
        {
            return _relatorioServices.ListaDeOperacoes();
        }
    }
}
