using Nutra.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;

namespace Nutra.API.Infrastructure;
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Desabilita o rastreamento automático de mudanças para melhorar a performance em consultas somente leitura
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            // Desabilita a detecção automática de mudanças para operações explícitas de atualização
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Questionarios> Questionarios { get; set; }
        public DbSet<Perguntas> Perguntas { get; set; }
        public DbSet<Opcoes> Opcao { get; set; }
        public DbSet<Respostas> Respostas { get; set; }
        public DbSet <TipoRegistro> TipoRegistro { get; set;}
        public DbSet <Registros> Registros { get; set; }
        
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura todas as propriedades do tipo string para varchar(100) por padrão
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string)))) 
                        property.SetColumnType("varchar(100)");

            // Aplica todas as configurações de mapeamento de entidades do assembly atual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Configurar o comportamento de exclusão em cascata para evitar exclusões acidentais
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null) )
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
