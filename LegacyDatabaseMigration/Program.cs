using System.Diagnostics;
using System.Text.Json;
using LegacyDatabaseMigration.CourseEvakData;
using LegacyDatabaseMigration.CourseEvalModels.CourseEvalFormModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VoceaUniversitatiiDataModels;
using VoceaUniversitatiiDataModels.Models;


namespace HttpClientSample;

public class Program
{
    private static DbContextOptionsBuilder<T> CreateOptions <T>(string database) where T : DbContext
    {
        var configuration = VoceaUniversitatiiConfigurations.ConfigurationManager.GetDevConfiguration();
        var connectionString = configuration.GetConnectionString(database);
        
        var dbContextOptions = new DbContextOptionsBuilder<T>();
        dbContextOptions.UseNpgsql(connectionString);
        
        return dbContextOptions;
    }
    
    static void Main()
    {
        DbContextOptionsBuilder<CourseevalDrept13122023Context> courseEvalOptions = CreateOptions<CourseevalDrept13122023Context>("CourseEvalDatabase");
        using (var legacyDataBaseContext = new CourseevalDrept13122023Context(courseEvalOptions.Options))
        {
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder2 = CreateOptions<DatabaseContext>("VoceaUniversitatiiDevDatabasse");
            using (var voceaUniversitatiiDatabaseContext = new DatabaseContext(optionsBuilder2.Options, null))
            {
                FormsMigration formsMigration = new FormsMigration(legacyDataBaseContext, voceaUniversitatiiDatabaseContext);
                formsMigration.Migrate();
            }
            
        }
    }
}