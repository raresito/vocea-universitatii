// https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client

using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using VoceaUniversitatiiConfigurations;
using VoceaUniversitatiiDataModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HttpClientSample
{
    class Program
    {
        static HttpClient client = new HttpClient();
        
        static void Main()
        {
            // RunAsync().GetAwaiter().GetResult();
            // IEnumerable<LegacyDepartment> departments = MigrateDepartments.GetDepartments();
            
            // Create Destination Database
            String TestDBConnectionString = CreateDestinationDatabase();

            DbContextOptions<DatabaseContext> dbContextOptions = new DbContextOptions<DatabaseContext>();
            AppConfiguration config = new AppConfiguration();
            config.ApiKey = TestDBConnectionString;
            config.DeploymentEnvironment = "LEGACY_MIGRATION";

            using (DbContext ctx = new DatabaseContext(dbContextOptions, config))
            {
                ctx.Database.Migrate();
            }
        }

        public static String CreateDestinationDatabase()
        {
            NpgsqlConnection m_conn = new NpgsqlConnection(Constants.LegacyDbConnectionString);
            string TestDbName = "testdb" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string CreateDatabaseSQL = $"CREATE DATABASE {TestDbName} " +
                                       $"WITH OWNER = {Constants.LegacyDbUsername} " +
                                       $"ENCODING = 'UTF8' " +
                                       $"CONNECTION LIMIT = -1; ";
            NpgsqlCommand m_createdb_cmd = new NpgsqlCommand(CreateDatabaseSQL, m_conn);
            m_conn.Open();
            m_createdb_cmd.ExecuteNonQuery();
            m_conn.Close();

            String connectionString = String.Format(
                "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer",
                Constants.LegacyDbHost,
                Constants.LegacyDbUsername,
                TestDbName,
                Constants.LegacyDbPort,
                Constants.LegacyDbPassword);

            m_conn = new NpgsqlConnection(connectionString);
            // NpgsqlCommand m_createtbl_cmd = new NpgsqlCommand(
            //     "CREATE TABLE table1(ID CHAR(256) CONSTRAINT id PRIMARY KEY, Title CHAR)"
            //     , m_conn);
            // m_conn.Open();
            // m_createtbl_cmd.ExecuteNonQuery();
            // m_conn.Close();
            Console.WriteLine("Finnished");
            return connectionString;
        }

        public static void DeleteDestinationDatabase()
        {
            string DatabaseToDelete = "testdb20240108192112";
            NpgsqlConnection m_conn = new NpgsqlConnection(
                String.Format("Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer", 
                    Constants.LegacyDbHost, 
                    Constants.LegacyDbUsername, 
                    Constants.LegacyDbName, 
                    Constants.LegacyDbPort, 
                    Constants.LegacyDbPassword)
            );
            
            NpgsqlCommand m_createtbl_cmd = new NpgsqlCommand(
                $"DROP DATABASE {DatabaseToDelete};", m_conn);
            m_conn.Open();
            m_createtbl_cmd.ExecuteNonQuery();
            m_conn.Close();
            Console.WriteLine("Finnished");
        }
    }
}