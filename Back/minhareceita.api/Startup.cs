using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using minhareceita.api.Configurations;
using minhareceita.data.Contexto;
using minhareceita.domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace minhareceita.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(o =>
            {
                //o.ModelBinderProviders.Insert(0, new JsonAndFileBinderProvider());
            });

            services.AddDbContext<AppDbContext>(o =>
            o.UseSqlServer(Configuration.GetConnectionString("SQL")));

            //services.AddIdentityConfig(Configuration);

            services.Configure<ApiBehaviorOptions>(o => o.SuppressModelStateInvalidFilter = true);

            services.AddCors(o =>
            {
                o.AddPolicy("Development", p =>
                    p.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddDI();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Development");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
