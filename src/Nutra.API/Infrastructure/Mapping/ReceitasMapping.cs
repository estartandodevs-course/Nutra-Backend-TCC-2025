using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;

public class ReceitasMapping
{
    public class MappingReceita : IEntityTypeConfiguration<Receitas>
    {
        public void Configure(EntityTypeBuilder<Receitas> builder)
        {
            builder.ToTable("Receitas");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .ValueGeneratedNever();

            builder.Property(r => r.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(r => r.Ingredientes)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(r => r.ModoPreparo)
                .IsRequired()
                .HasColumnType("text");

            builder.Property(r => r.ImagemBase64)
                .HasColumnType("longtext");
        }
    }
}
