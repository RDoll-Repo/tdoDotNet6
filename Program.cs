using Microsoft.EntityFrameworkCore;
using Npgsql;
using todoDotNet6.Services;
using todoDotNet6.db;

var stringBuilder = new NpgsqlConnectionStringBuilder()
{
    Host = "localhost",
    Port = 5432,
    Username = "postgres",
    Password = "password",
    Database = "tododb"
};
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(stringBuilder.ConnectionString)
        .UseSnakeCaseNamingConvention()
        );


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, Repository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
