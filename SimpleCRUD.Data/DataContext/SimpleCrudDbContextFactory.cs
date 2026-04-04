using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SimpleCRUD.Data.DataContext
{
    public class SimpleCrudDbContextFactory : IDesignTimeDbContextFactory<SimpleCrudDbContext>
    {
        public SimpleCrudDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.Migrations.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' was not found in appsettings.Migrations.json.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<SimpleCrudDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SimpleCrudDbContext(optionsBuilder.Options);
        }
    }
}