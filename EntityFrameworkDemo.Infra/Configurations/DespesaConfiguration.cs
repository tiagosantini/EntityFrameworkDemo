using EntityFrameworkDemo.Dominio.Entities.DespesaModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDemo.Infra.Configurations
{
    public class DespesaConfiguration : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("TBDespesa");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Descricao).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(d => d.Valor).HasColumnType("DECIMAL(18,2)").IsRequired();
            builder.Property(d => d.TipoDespesa).HasConversion<string>().IsRequired();
        }
    }
}
