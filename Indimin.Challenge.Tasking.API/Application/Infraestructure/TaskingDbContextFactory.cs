using Indimin.Challenge.Tasking.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Indimin.Challenge.Tasking.API.Application.Infraestructure
{
    public class TaskingDbContextFactory : IDesignTimeDbContextFactory<TaskingDbContext>
    {
        public TaskingDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TaskingDbContext>();

            optionsBuilder.UseSqlServer(config["DatabaseSettings:ConnectionString"], sqlServerOptionsAction: o => o.MigrationsAssembly("Indimin.Challenge.Tasking.API"));

            return new TaskingDbContext(optionsBuilder.Options);
        }
    }
}
