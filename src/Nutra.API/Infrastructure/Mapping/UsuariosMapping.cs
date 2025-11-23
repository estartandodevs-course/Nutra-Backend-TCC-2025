using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;

public class UsuariosMapping
{
    public class MappingUsuario : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");
        }
    }
}