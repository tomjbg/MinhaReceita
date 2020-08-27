using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using minhareceita.data.Contexto;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;

namespace minhareceita.api.Configurations.FactoriesContext
{
    public class IdentityAppDbContextFactory : IDesignTimeDbContextFactory<IdentityAppDbContext>
    {
        public IdentityAppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<IdentityAppDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SQL"));

            return new IdentityAppDbContext(optionsBuilder.Options);

        }
    }
}
