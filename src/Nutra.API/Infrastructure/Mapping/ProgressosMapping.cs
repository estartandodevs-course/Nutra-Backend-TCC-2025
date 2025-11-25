using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping
{
    public class ProgressosMapping : IEntityTypeConfiguration<Progressos>
    {
        public void Configure(EntityTypeBuilder<Progressos> builder)
        {
            builder.ToTable("Progressos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Completo)
                .IsRequired();

            builder.Property(p => p.DataConclusao);

            builder.Property(p => p.QuantidadeAtual)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.IdUsuario)
                .IsRequired();

            builder.Property(p => p.IdDesafio)
                .IsRequired();

            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Desafio)
                .WithMany()
                .HasForeignKey(p => p.IdDesafio)
                .OnDelete(DeleteBehavior.Restrict);        }
    }
}
