using Invest.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invest.Entities.Configurations
{
    public class AcaoConfiguration : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.ToTable("acao");
            
            builder.HasKey(k => k.AcaoId);
            builder.Property(p => p.AcaoId).HasColumnName("acao_id");
            
            builder.Property(e => e.RazaoSocial)
                .IsRequired()
                .HasColumnName("razao_social")
                .HasMaxLength(100);

            builder.HasMany(e => e.operacao)
                .WithOne(o => o.acao)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
