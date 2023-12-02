using Application;
using Application.DTOs.CourseDTOs;
using Application.Validators;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





// Creating the context object for
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(
        builder.
        Configuration.GetConnectionString("DefaultConnectionString"),
        builder => builder.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)),
        ServiceLifetime.Transient
    );


// Dependency injection for the context object
builder.Services.AddScoped<IApplicationDBContext>(
    provider => provider.GetRequiredService<ApplicationDBContext>()
);

// service for type 'MediatR.ISender' has been registered.
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});



// register Validator with the service provider
builder.Services.AddScoped<IValidator<AddCourseDTO>, CourseValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<CourseValidator>();


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
