using LegacyDatabaseMigration.CourseEvakData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VoceaUniversitatiiDataModels;

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
            using (var voceaUniversitatiiDatabaseContext = new DatabaseContext(optionsBuilder2.Options))
            {
                FormsMigration formsMigration = new FormsMigration(legacyDataBaseContext, voceaUniversitatiiDatabaseContext);
                formsMigration.Migrate();
            }
            
        }
    }
}