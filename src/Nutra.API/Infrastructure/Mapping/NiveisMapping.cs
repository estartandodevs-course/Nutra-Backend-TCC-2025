using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping
{
    public class NiveisMapping : IEntityTypeConfiguration<Niveis>
    {
        public void Configure(EntityTypeBuilder<Niveis> builder)
        {
            builder.ToTable("Niveis");

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(n => n.Descricao)
                .HasColumnType("varchar(200)");

            builder.Property(n => n.XpNecessario)
                .IsRequired();
        }
    }
}
