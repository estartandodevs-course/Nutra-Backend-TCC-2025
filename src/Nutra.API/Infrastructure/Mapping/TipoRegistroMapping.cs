using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;

public class TipoRegistroMapping : IEntityTypeConfiguration<TipoRegistro>
{
    public void Configure(EntityTypeBuilder<TipoRegistro> builder)
    {
        builder.ToTable("TiposRegistro");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Categoria)
            .IsRequired()
            .HasColumnName("Categoria")
            .HasConversion<string>(); 

        builder.HasIndex(t => t.Categoria)
            .IsUnique();
        
        builder.Property(t => t.Descricao)
            .HasMaxLength(500)
            .HasColumnName("Descricao");
        
        builder.HasMany(t => t.Registros)
            .WithOne(r => r.Tipo)
            .HasForeignKey(r => r.IdTipoRegistro)
            .OnDelete(DeleteBehavior.Restrict);
    }
}