using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;

public class QuestionarioConfiguration : IEntityTypeConfiguration<Questionarios>
{
    public void Configure(EntityTypeBuilder<Questionarios> builder)
    {
        builder.ToTable("Questionarios");
        
        builder.HasKey(q => q.Id);
        
        builder.Property(q => q.Titulo)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(q => q.Ativo)
            .IsRequired()
            .HasDefaultValue(true);
        
        builder.HasMany(q => q.Perguntas)
            .WithOne(p => p.Questionarios)
            .HasForeignKey(p => p.IdQuestionario)
            .OnDelete(DeleteBehavior.Cascade);
    }
}