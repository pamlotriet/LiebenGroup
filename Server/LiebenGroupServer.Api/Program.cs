using LiebenGroupServer.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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


// Add database context 
var Configuration = builder.Configuration;
builder.Services.AddDbContext<DBContext>(options =>
        options.UseSqlServer (Configuration.GetConnectionString("DbConnection")));



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
