using Invest.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invest.Repositories.Context
{
    public partial class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseContext(DbContextOptions<TContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SafraInvest");
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Operacao>()
                .HasOne(o => o.acao);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
