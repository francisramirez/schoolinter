using Microsoft.EntityFrameworkCore;
using School.AppServices.Contracts;
using School.AppServices.Service;
using School.Infraestructure.Context;
using School.Infraestructure.Dao;
using School.Infraestructure.Interfaces;
using School.IOC.CourseDependencies;
using School.IOC.DepartmentDependencies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));
//builder.Services.AddDbContextPool

// Depedencias el modulo de departamento //

builder.Services.AddDepartmentDependency();

builder.Services.AddCourseDependency();

// Add services to the container.
//builder.Services.AddScoped<IDepartmentDb, DepartmentDb>();


//App Services
//builder.Services.AddTransient<IDepartmentService, DepartmentService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
