namespace vocea_universitatii.Helpers;

using Microsoft.EntityFrameworkCore;

public class FacultyContext : DbContext
{
    protected readonly IConfiguration Configuration;

    // public FacultyContext(DbContextOptions<FacultyContext> options)
    public FacultyContext(DbContextOptions<FacultyContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<Faculty> Faculties { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("VoceaDatabase"));
    }
}