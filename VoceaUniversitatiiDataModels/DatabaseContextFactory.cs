using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using VoceaUniversitatiiConfigurations;

namespace VoceaUniversitatiiDataModels;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    private AppConfiguration _config = new AppConfiguration();

    public DatabaseContextFactory()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<DatabaseContextFactory>().Build();
        var secretProvider = config.Providers.First();
        secretProvider.TryGet("ElephantSqlStaging", out var ApiKey);
        _config.ApiKey = ApiKey;
    }
    
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseNpgsql(DatabaseContext.ElephantSQLConnectionString(_config.ApiKey),
            x => 
                x.MigrationsAssembly ("VoceaUniversitatiiMigrations"));
        return new DatabaseContext(optionsBuilder.Options, _config);
    }
}