using Invest.Entities;
using Invest.Repositories;
using Invest.Repositories.Context;
using Invest.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services.Business
{
    public class AcaoServices : BaseServices<Acao>, IAcaoServices
    {
        protected AcaoRepository _acaoRepository;
        public AcaoServices(DataContext context) : base(context)
        {
            _context = context;
            _acaoRepository = AcaoRepository.GetAcaoRepository(_context);
        }
        public static AcaoServices GetAcaoServices(DataContext context) { return new AcaoServices(context); }

        public override async Task<ActionResult<IEnumerable<Acao>>> ListarTodos()
        {
            return await (from ac in _acaoRepository.GetAll() select ac).ToListAsync();
        }

        public override bool Inserir(Acao entity)
        {
            if (entity != null)
            {
                _context.Acoes.Add(entity);
                _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Atualizar(Acao entity)
        {
            if(entity != null)
            {
                _context.Acoes.Update(entity);
                _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public override bool Deletar(string id)
        {
            var entity = _acaoRepository.GetById(id);
            if (entity != null)
            {
                _context.Acoes.Remove(entity.FirstOrDefault());
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public async Task<ActionResult<IEnumerable<Acao>>> ListarPorRazaoSocial(string razao)
        {
            return await _context.Acoes.Where(w => w.RazaoSocial.ToUpper().Contains(razao.ToUpper())).ToListAsync();
        }

        public async Task<ActionResult<Acao>> ListarPorId(string Id)
        {
            return await _context.Acoes.Where(w => w.AcaoId.ToUpper() == Id.ToUpper()).FirstOrDefaultAsync();
        }
    }
}
