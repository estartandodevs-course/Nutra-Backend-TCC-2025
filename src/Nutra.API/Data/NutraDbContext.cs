using Microsoft.EntityFrameworkCore;

namespace Nutra.API.Data;

public class NutraDbContext : DbContext
{
    public NutraDbContext(DbContextOptions<NutraDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Model configuration will be added here as needed
        base.OnModelCreating(modelBuilder);
    }
}


