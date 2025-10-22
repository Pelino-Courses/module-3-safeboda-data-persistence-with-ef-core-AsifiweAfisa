using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SafeBoda;
using System.IO;
using SafeBoda.Infrastructure;
using SafeBoda.Persistence;


public class SafeBodaDbContextFactory : IDesignTimeDbContextFactory<SafeBodaDbContext>
{
    public SafeBodaDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json") // Or whatever config file you use
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<SafeBodaDbContext>();
        var connectionString = configuration.GetConnectionString("SafeBodaDb");
        
        optionsBuilder.UseSqlServer(connectionString);

        return new SafeBodaDbContext(optionsBuilder.Options);
    }
}