using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;

public class PerguntaConfiguration : IEntityTypeConfiguration<Perguntas>
{
    public void Configure(EntityTypeBuilder<Perguntas> builder)
    {
        builder.ToTable("Perguntas");
        
        builder.HasKey(p => p.Id);
        
        // Propriedades
        builder.Property(p => p.Enunciado)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(p => p.IdQuestionario)
            .IsRequired();
        
        // Relacionamentos
        builder.HasOne(p => p.Questionarios)
            .WithMany(q => q.Perguntas)
            .HasForeignKey(p => p.IdQuestionario)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.OpcoesRespostas)
            .WithOne(o => o.Perguntas)
            .HasForeignKey(o => o.IdPergunta)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}