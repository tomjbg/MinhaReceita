using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minhareceita.data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace minhareceita.api.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<IdentityStoreContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("SQL"));
            })
            .AddIdentity<ApplicationUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequiredLength = 6;
                o.Password.RequireUppercase = false;

                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                o.Lockout.MaxFailedAccessAttempts = 3;

                o.User.RequireUniqueEmail = true;

            })
            .AddEntityFrameworkStores<IdentityStoreContext>()
            .AddDefaultTokenProviders();


            return services;
        }
    }
}
