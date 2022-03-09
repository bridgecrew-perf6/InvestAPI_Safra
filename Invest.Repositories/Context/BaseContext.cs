using Invest.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Invest.Repositories.Context
{
    public partial class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseContext(DbContextOptions<TContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SafraInvest");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcaoConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OperacaoConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TipoOperacaoConfiguration).Assembly);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
