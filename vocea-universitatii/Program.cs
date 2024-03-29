using System.Diagnostics;
using System.Reflection;
using VoceaUniversitatii.Services.DepartmentService;
using VoceaUniversitatii.Services.DisciplineService;
using VoceaUniversitatii.Services.FacultyService;
using VoceaUniversitatii.Services.StudentCohortService;
using VoceaUniversitatii.Services.StudyProgramService;
using VoceaUniversitatii.Services.TeacherService;
using VoceaUniversitatii.Services.TeacherTitleService;
using VoceaUniversitatiiConfigurations;
using VoceaUniversitatiiDataModels;

// global using vocea_universitatii.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ITeacherTitleService, TeacherTitleService>();
builder.Services.AddScoped<IStudyProgramService, StudyProgramService>();
builder.Services.AddScoped<IStudentCohortService, StudentCohortService>();
builder.Services.AddScoped<IDisciplineService, DisciplineService>();
builder.Services.AddDbContext<DatabaseContext>();

// Use AppConfiguration singleton to manage secrets.
var config = new AppConfiguration();

// Console.WriteLine(builder.Environment.EnvironmentName);
// Database selection based on Environment
if (builder.Environment.IsStaging())
{
    // Force dotnet to read user-secrets in Staging Environment too.
    builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
    config.ApiKey = builder.Configuration["ElephantSqlStaging"];
}

if (builder.Environment.IsDevelopment())
{
    config.ApiKey = builder.Configuration["DatabaseKeys:ElephantSql-Key-Development"];
}
_ = config.ApiKey ?? throw new Exception("Environment not set. Cannot choose Database.");

builder.Services.AddSingleton<AppConfiguration>(config);

var app = builder.Build();

// Require Swagger in both Development and Staging
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// The database didn't process the dates properly.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseAuthorization();

app.MapControllers();

app.Run();