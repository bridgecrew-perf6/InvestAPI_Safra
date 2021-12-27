using Invest.Entities;
using Invest.Repositories.Context;
using Invest.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Repositories
{
    public class AcaoRepository : BaseRepository<Acao>, IAcaoRepository
    {
        public AcaoRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public static AcaoRepository GetAcaoRepository(DataContext context) { return new AcaoRepository(context); }

        public IQueryable<Acao> GetById(string id)
        {
            return _context.Acoes.Where(w => w.AcaoId == id);
        }

        public IQueryable<Acao> GetByRazao(string razao)
        {
            return _context.Acoes.Where(a => a.RazaoSocial.Contains(razao));
        }
    }
}
