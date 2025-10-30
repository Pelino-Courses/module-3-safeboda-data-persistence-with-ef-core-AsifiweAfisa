using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SafeBoda;
using SafeBoda.Infrastructure;
using SafeBoda.Persistence;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("SafeBodaDb");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string 'SafeBodaDb' is not configured.");
}

builder.Services.AddDbContext<SafeBodaDbContext>(options =>
{
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))); 
});

builder.Services.AddScoped<ITripRepository, EfTripRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();