
using LiebenGroupServer.Api.Middelware;
using LiebenGroupServer.Application.Commands.Product;
using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.DataAccess.DatabaseContext;
using LiebenGroupServer.DataAccess.Models;
using LiebenGroupServer.DataAccess.Repostories;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly);
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

//Add CORS 
builder.Services.AddCors(options =>
{
    string MyAllowSpecificOrigins = "";
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
        });
});


// Configure Mapster
var config = TypeAdapterConfig.GlobalSettings;


//define mappings 
config.NewConfig<OrderDto, Order>();
config.NewConfig<ProductDto, Product>();

// Add database context 
var Configuration = builder.Configuration;
builder.Services.AddDbContext<DBContext>(options =>
        options.UseSqlServer (Configuration.GetConnectionString("DbConnection")));

//DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandler>();
app.MapControllers();

app.Run();
