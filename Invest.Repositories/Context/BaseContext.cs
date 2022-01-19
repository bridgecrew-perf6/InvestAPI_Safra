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
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
