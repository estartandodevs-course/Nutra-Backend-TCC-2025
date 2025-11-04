using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;

namespace Nutra.API.Data;

public class NutraDbContext : DbContext
{
    public NutraDbContext(DbContextOptions<NutraDbContext> options) : base(options) { }

    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var order = modelBuilder.Entity<OrderEntity>();
        order.ToTable("orders");
        order.HasKey(o => o.Id);
        order.Property(o => o.Id).HasMaxLength(50).IsRequired();
        order.Property(o => o.CustomerId).HasMaxLength(100).IsRequired();
        order.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
        order.Property(o => o.OrderDate).IsRequired();
        order.Property(o => o.CreatedAt).IsRequired();
        order.Property(o => o.UpdatedAt);

        // Store Items as JSON (simple approach)
        order.Property(o => o.Items)
             .HasColumnType("json");
    }
}


