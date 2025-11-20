using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure.Mapping;

public class RespostasConfiguration : IEntityTypeConfiguration<Respostas>
{
    public void Configure(EntityTypeBuilder<Respostas> builder)
    {
        builder.ToTable("Respostas");
        
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Descricao)
            .HasMaxLength(300)
            .IsRequired(false);
        
        builder.Property(r => r.IdUsuario)
            .IsRequired();
        
        builder.Property(r => r.IdOpcao)
            .IsRequired();
        
        builder.Property(r => r.IdPergunta)
            .IsRequired();
        
        builder.Property(r => r.IdQuestionario)
            .IsRequired();
        
        builder.HasOne(r => r.Usuarios)
            .WithMany(u => u.Respostas)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(r => r.Questionarios)
            .WithMany() 
            .HasForeignKey(r => r.IdQuestionario)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(r => r.Perguntas)
            .WithMany() 
            .HasForeignKey(r => r.IdPergunta)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(r => r.Opcoes)
            .WithMany() 
            .HasForeignKey(r => r.IdOpcao)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}