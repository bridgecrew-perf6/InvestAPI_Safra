using Invest.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Invest.Repositories.Context
{
    public class DataContext : BaseContext<DataContext>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<TipoOperacao> TipoOperacoes { get; set; }
    }
}
