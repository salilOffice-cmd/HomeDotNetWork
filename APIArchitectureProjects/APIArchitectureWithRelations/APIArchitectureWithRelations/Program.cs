using APIArchitectureWithRelations.Context;
using APIArchitectureWithRelations.Data_Access_Layer;
using APIArchitectureWithRelations.Middleware;
using APIArchitectureWithRelations.Service_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Registering for DBContext
builder.Services.AddDbContext<Company2DBContext>(options =>
options.
UseSqlServer(builder.Configuration.GetConnectionString("officeConnString")));


// Registering for other dependencies in the DI container
builder.Services.AddScoped<IFloorRepo, FloorRepository>();
builder.Services.AddScoped<IFloorService, FloorService>();

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<ISystemDetailRepo, SystemDetailRepository>();
builder.Services.AddScoped<ISystemDetailService, SystemDetailService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMvc(options =>
//{
//    options.SuppressAsyncSuffixInActionNames = false;
//});

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

//app.UseMiddleware<GlobalExceptionMidd>();

app.Run();

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio
