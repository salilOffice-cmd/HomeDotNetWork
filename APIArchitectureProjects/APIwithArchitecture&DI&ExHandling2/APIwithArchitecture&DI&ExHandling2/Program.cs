using APIwithArchitecture.Contexts;
using APIwithArchitecture.Data_Access_Layer;
using APIwithArchitecture.Services;
using APIwithArchitecture_DI.Data_Access_Layer;
using APIwithArchitecture_DI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<OrdersDBContext>(options =>
options.
UseSqlServer(builder.Configuration.GetConnectionString("localConnString")));


// Registering for other dependencies in the DI container
builder.Services.AddScoped<IOrderRespository, OrderRespository>();
builder.Services.AddScoped<IOrderService, OrderService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
