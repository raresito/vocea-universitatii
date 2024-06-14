namespace VoceaUniversitatiiConfigurations;

using Microsoft.Extensions.Configuration;

public static class ConfigurationManager
{
    public static IConfigurationRoot GetDevConfiguration()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true);
        return builder.Build();
    }
}