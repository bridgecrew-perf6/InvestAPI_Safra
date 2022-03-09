using Invest.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invest.Entities.Configurations
{
    public class TipoOperacaoConfiguration : IEntityTypeConfiguration<TipoOperacao>
    {
        public void Configure(EntityTypeBuilder<TipoOperacao> builder)
        {
            builder.ToTable("tipo_operacao");

            builder.HasKey(k => k.tipoId);
            builder.Property(p => p.tipoId)
                .HasColumnName("tipo_operacao_id");

            builder.Property(p => p.sigla)
                .IsRequired()
                .HasColumnName("tipo_operacao_sigla");

            builder.Property(p => p.descricao)
                .IsRequired()
                .HasColumnName("tipo_operacao_descricao");
        }
    }
}
