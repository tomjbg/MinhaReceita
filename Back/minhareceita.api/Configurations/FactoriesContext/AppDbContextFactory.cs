using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using minhareceita.data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace minhareceita.api.Configurations.FactoriesContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").AddJsonFile("appsettings.Development.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SQL"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
