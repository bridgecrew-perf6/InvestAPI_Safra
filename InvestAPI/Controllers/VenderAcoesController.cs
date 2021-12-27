using Invest.Repositories.Context;
using Invest.Services.Business;
using Invest.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InvestAPI.Controllers
{
    [Route("api/VenderAcoes")]
    [ApiController]
    public class VenderAcoesController : Controller
    {
        private readonly DataContext _context;
        protected OperacaoServices _operacaoServices;

        public VenderAcoesController(DataContext context)
        {
            _context = context;
            _operacaoServices = OperacaoServices.GetOperacaoServices(_context);
        }
        
        [HttpPost]
        public void VenderAcoes([FromBody]VendaVM venda)
        {
            _operacaoServices.VenderAcoes(venda);
        }
    }
}
