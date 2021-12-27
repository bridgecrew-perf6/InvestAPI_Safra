using Invest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Repositories.Context
{
    public class DataContext : BaseContext<DataContext>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
    }
}
