using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;
using Nutra.Domain.Enums;

namespace Nutra.API.Infrastructure.Mapping;

    public class MappingUsuario : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(u => u.Turma)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(u => u.Tipo)
                .IsRequired()
                .HasConversion<string>()
                .HasDefaultValue(TipoUsuario.Aluno);

            builder.Property(u => u.XpTotal).IsRequired();
            builder.Property(u => u.Ativo).IsRequired();

            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.UpdatedAt);

            builder.HasMany(u => u.Respostas)
                .WithOne(r => r.Usuarios)
                .HasForeignKey(r => r.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
