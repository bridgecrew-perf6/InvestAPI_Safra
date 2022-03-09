using System;
using System.Linq;
using System.Threading.Tasks;
using Invest.Entities.Models;
using Invest.Repositories.Context;
using Invest.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Invest.Repositories
{
    public class AcaoRepository : BaseRepository, IAcaoRepository
    {
        public AcaoRepository(DataContext context) : base(context)
        {
        }

        public async Task<Acao> GetByAcaoId(string acaoId)
        {
            try
            {
                return await _context.Set<Acao>()
                    .Where(w => w.AcaoId == acaoId)
                    .FirstOrDefaultAsync();
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
                return await _context.Acoes.OrderBy(e => e.AcaoId)
                    .Where(a => a.RazaoSocial.ToLower().Contains(razao.ToLower()))
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<object> GetAll()
        {
            return await _context.Acoes.ToArrayAsync();
        }
    }
}
