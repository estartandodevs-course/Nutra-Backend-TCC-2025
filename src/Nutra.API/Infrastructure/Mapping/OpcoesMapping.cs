using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;

public class OpcaoConfiguration : IEntityTypeConfiguration<Opcoes>
{
    public void Configure(EntityTypeBuilder<Opcoes> builder)
    {
        builder.ToTable("Opcoes");
        
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Descricao)
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(o => o.IdPergunta)
            .IsRequired();
        
        builder.HasOne(o => o.Perguntas)
            .WithMany(p => p.OpcoesRespostas)
            .HasForeignKey(o => o.IdPergunta)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}