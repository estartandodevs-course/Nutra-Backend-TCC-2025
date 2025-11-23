using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;
public class RegistroMapping : IEntityTypeConfiguration<Registros>
{
    public void Configure(EntityTypeBuilder<Registros> builder)
    {
        builder.ToTable("Registros");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Quantidade)
            .HasColumnName("Quantidade")
            .IsRequired();

        builder.Property(r => r.Observacao)
            .HasColumnName("Observacao")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(r => r.IdUsuario)
            .HasColumnName("IdUsuario")
            .IsRequired();

        builder.Property(r => r.IdTipoRegistro)
            .HasColumnName("IdTipoRegistro")
            .IsRequired();

        builder.HasOne(r => r.Usuarios)
            .WithMany()
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Tipo)
            .WithMany(t => t.Registros)
            .HasForeignKey(r => r.IdTipoRegistro)
            .OnDelete(DeleteBehavior.Restrict);
    }
}