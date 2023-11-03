using vocea_universitatii.Models;

namespace vocea_universitatii.Helpers;

using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public DbSet<Faculty> Faculties { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("VoceaDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new FacultyEntityTypeConfiguration().Configure(modelBuilder.Entity<Faculty>());
        new DepartmentEntityTypeConfiguration().Configure(modelBuilder.Entity<Department>());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseModel && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseModel)entityEntry.Entity).UpdatedAt = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseModel)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}