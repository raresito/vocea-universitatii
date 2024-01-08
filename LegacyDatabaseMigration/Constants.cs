namespace HttpClientSample;

public class Constants
{
    public static string LegacyDbHost = "localhost";
    public static string LegacyDbUsername = "rares";
    public static string LegacyDbName = "courseeval_production_april_2023";
    public static string LegacyDbPassword = "";
    public static string LegacyDbPort = "5432";
    
    public static string LegacyDbConnectionString =
        String.Format(
            "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer", 
            Constants.LegacyDbHost, 
            Constants.LegacyDbUsername, 
            Constants.LegacyDbName, 
            Constants.LegacyDbPort, 
            Constants.LegacyDbPassword);
}