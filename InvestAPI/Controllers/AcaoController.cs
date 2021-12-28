using Invest.Entities;
using Invest.Repositories.Context;
using Invest.Services.Business;
using Invest.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestAPI.Controllers
{
    [Route("api/Acao")]
    [ApiController]
    public class AcaoController : ControllerBase
    {
        private readonly DataContext _context;
        protected IAcaoServices _acaoServices;
        public AcaoController(DataContext context)
        {
            _context = context;
            _acaoServices = AcaoServices.GetAcaoServices(_context);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acao>>> Get()
        {
            try
            {
                return await _acaoServices.ListarTodos();
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
        
        [HttpGet("codigo/{id}")]
        public async Task<ActionResult<Acao>> GetByCodigo(string id)
        {
            try
            {
                return await _acaoServices.ListarPorId(id);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        
        [HttpGet("razao/{razao}")]
        public async Task<ActionResult<IEnumerable<Acao>>> GetByRazao(string razao)
        {
            try
            {
                return await _acaoServices.ListarPorRazaoSocial(razao);
                
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPost]
        public bool Post(Acao acao)
        {
            try
            {
                return _acaoServices.Inserir(acao);
                
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        [HttpPut]
        public bool Put(Acao acao)
        {
            try
            {
                return _acaoServices.Atualizar(acao);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            try
            {
                return _acaoServices.Deletar(id);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
