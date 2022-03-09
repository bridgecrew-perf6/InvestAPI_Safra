using Invest.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invest.Entities.Configurations
{
    public class OperacaoConfiguration : IEntityTypeConfiguration<Operacao>
    {
        public void Configure(EntityTypeBuilder<Operacao> builder)
        {
            builder.ToTable("operacao");

            builder.HasKey(k => k.OperacaoId);
            builder.Property(p => p.OperacaoId).HasColumnName("operacao_id");

            builder.Property(p => p.PrecoAcao)
                .IsRequired()
                .HasColumnName("preco_acao");

            builder.Property(p => p.Data)
                .IsRequired()
                .HasColumnName("data_operacao");

            builder.Property(p => p.Total)
                .IsRequired()
                .HasColumnName("total_operacao");

            builder.Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnName("qtd_acao");

            builder.Property(p => p.AcaoId).HasColumnName("acao_id");
            builder.HasOne(g => g.acao).WithMany(m => m.operacao);
                //.HasForeignKey(f => f.OperacaoId).HasConstraintName("operacao_fk");

            builder.Property(p => p.TipoOperacaoId).HasColumnName("tipo_operacao_id");
            builder.HasOne(o => o.TipoOperacao).WithOne(w => w.operacao);
                //.HasForeignKey("operacao_fk_1");
        }
    }
}
