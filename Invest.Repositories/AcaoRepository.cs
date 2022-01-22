using System;
using System.Linq;
using System.Threading.Tasks;
using Invest.Entities;
using Invest.Repositories.Context;
using Invest.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Invest.Repositories
{
    public class AcaoRepository : IAcaoRepository
    {
        private readonly DataContext _context;

        public AcaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Acao[]> GetAll()
        {
            try
            {
                return await _context.Acoes.OrderBy(e => e.AcaoId).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Acao> GetById(string id)
        {
            try
            {
                return await _context.Acoes.Where(w => w.AcaoId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Acao[]> GetByRazao(string razao)
        {
            try
            {
                return await _context.Acoes.OrderBy(e => e.AcaoId).Where(a => a.RazaoSocial.Contains(razao)).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Insert(Acao entity)
        {
            _context.Add<Acao>(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(Acao entity)
        {
            _context.Update<Acao>(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> Delete(Acao entity)
        {
            _context.Remove<Acao>(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }        
    }
}
