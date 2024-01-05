using DotnetYuzuncuYilBootcamp.Core.Repositories;
using DotnetYuzuncuYilBootcamp.Core.Services;
using DotnetYuzuncuYilBootcamp.Core.UnitOfWorks;
using DotnetYuzuncuYilBootcamp.Repository;
using DotnetYuzuncuYilBootcamp.Repository.Repositories;
using DotnetYuzuncuYilBootcamp.Repository.UnitOfWorks;
using DotnetYuzuncuYilBootcamp.Service.Mapping;
using DotnetYuzuncuYilBootcamp.Service.Services;
using DotnetYuzuncuYilBootcamp.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(); 
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IDutyService, DutyService>();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddControllers()
    .AddFluentValidation(x => 
    {
        x.RegisterValidatorsFromAssemblyContaining<DutyDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<EmployeeDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<EmployeeProfileDtoValidator>();
    });

//AppDbContext i�lemleri 
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option => 
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
