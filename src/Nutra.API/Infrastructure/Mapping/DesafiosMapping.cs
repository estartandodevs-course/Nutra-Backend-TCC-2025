using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping
{
    public class DesafiosMapping : IEntityTypeConfiguration<Desafios>
    {
        public void Configure(EntityTypeBuilder<Desafios> builder)
        {
            builder.ToTable("Desafios");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(d => d.Descricao)
                .HasColumnType("varchar(100)");

            builder.Property(d => d.QuantidadeMeta)
                .IsRequired();

            builder.Property(d => d.XpRecompensa)
                .IsRequired();

            builder.Property(d => d.Ativo)
                .IsRequired();

            builder.Property(d => d.IdTipoRegistro)
                .IsRequired();

            builder.HasOne(d => d.TipoRegistro)
                .WithMany()
                .HasForeignKey(d => d.IdTipoRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
