using vocea_universitatii.Models;

namespace vocea_universitatii.Helpers;

using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    protected readonly IConfiguration Configuration;
    private AppConfiguration _config;
    
    public DbSet<Faculty> Faculties { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration, AppConfiguration config)
        : base(options)
    {
        _config = config;
        Configuration = configuration;
    }
    
    public string ElephantSQLConnectionString(string ConnectionString)
    {
        var uri = new Uri(ConnectionString);
        var db = uri.AbsolutePath.Trim('/');
        var user = uri.UserInfo.Split(':')[0];
        var passwd = uri.UserInfo.Split(':')[1];
        var port = uri.Port > 0 ? uri.Port : 5432;
        var connStr = $"Server={uri.Host};Database={db};User Id={user};Password={passwd};Port={port}";
        Console.WriteLine(connStr);
        return connStr;
    }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        // options.UseNpgsql(Configuration.GetConnectionString("VoceaDatabase"));
        
        // connect to postgres hosted database on ElephantSQL
        options.UseNpgsql(ElephantSQLConnectionString(_config.ApiKey));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new FacultyEntityTypeConfiguration().Configure(modelBuilder.Entity<Faculty>());
        new DepartmentEntityTypeConfiguration().Configure(modelBuilder.Entity<Department>());
        new TeacherEntityTypeConfiguration().Configure(modelBuilder.Entity<Teacher>());

        modelBuilder.Entity<TeacherDepartmentMembership>()
            .HasKey(lc => new { lc.TeacherId, lc.DepartmentId });
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