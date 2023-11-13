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
    public DbSet<TeacherTitle> TeacherTitles { get; set; } = null!;
    
    public DbSet<AcademicYear> AcademicYears { get; set; } = null!;
    public DbSet<StudyProgram> StudyPrograms { get; set; } = null!;

    public DbSet<StudentCohort> StudentCohorts { get; set; } = null!;

    public DbSet<Cohort> Cohorts { get; set; } = null!;

    public DbSet<StudyYear> StudyYears { get; set; } = null!;

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
        new TeacherTitleEntityTypeConfiguration().Configure(modelBuilder.Entity<TeacherTitle>());
        new AcademicYearEntityTypeConfiguration().Configure(modelBuilder.Entity<AcademicYear>());
        new StudyProgramEntityTypeConfiguration().Configure(modelBuilder.Entity<StudyProgram>());
        new LanguageEntityTypeConfiguration().Configure(modelBuilder.Entity<Language>());
        new StudentCohortEntityTypeConfiguration().Configure(modelBuilder.Entity<StudentCohort>());
        new CohortsEntityTypeConfiguration().Configure(modelBuilder.Entity<Cohort>());
        
        modelBuilder.Entity<TeacherDepartmentMembership>()
            .HasKey(lc => new { lc.TeacherId, lc.DepartmentId });
        
        modelBuilder.Entity<StudyProgramAcademicYearEnrollments>()
            .HasKey(spaye => new { spaye.StudyProgramId, spaye.AcademicYearId });
        
        modelBuilder.Entity<StudyYear>()
            .HasData(
                new StudyYear { Id = 1, Name = "Anul I - Licență" },
                new StudyYear { Id = 2, Name = "Anul II - Licență" },
                new StudyYear { Id = 3, Name = "Anul III - Licență" },
                new StudyYear { Id = 4, Name = "Anul IV - Licență" },
                new StudyYear { Id = 5, Name = "Anul I - Master" },
                new StudyYear { Id = 6, Name = "Anul II - Master" },
                new StudyYear { Id = 7, Name = "Doctorat" }
            );
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