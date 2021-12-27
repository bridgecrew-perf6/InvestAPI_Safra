using Invest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Repositories.Contracts
{
    public interface IAcaoRepository : IBaseRepository<Acao>
    {
        IQueryable<Acao> GetById(string id);
        IQueryable<Acao> GetByRazao(string razao);
    }
}
