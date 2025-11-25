using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping
{
    public class RegrasDesafiosMapping : IEntityTypeConfiguration<RegrasDesafios>
    {
        public void Configure(EntityTypeBuilder<RegrasDesafios> builder)
        {
            builder.ToTable("RegrasDesafios");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.IdOpcao)
                .IsRequired();

            builder.Property(d => d.IdDesafio)
                .IsRequired();

            builder.HasOne(d => d.Opcoes)
                .WithMany()
                .HasForeignKey(d => d.IdOpcao)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Desafios)
                .WithMany()
                .HasForeignKey(d => d.IdDesafio)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
