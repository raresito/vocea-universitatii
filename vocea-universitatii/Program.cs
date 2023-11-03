using Microsoft.EntityFrameworkCore;
using vocea_universitatii.Helpers;
using vocea_universitatii.Services.DepartmentService;
using vocea_universitatii.Services.FacultyService;

// global using vocea_universitatii.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddDbContext<DatabaseContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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