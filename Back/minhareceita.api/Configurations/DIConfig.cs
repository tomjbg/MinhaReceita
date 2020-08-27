using Microsoft.Extensions.DependencyInjection;
using minhareceita.data.Repositorios;
using minhareceita.domain.Interfaces;
using minhareceita.domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minhareceita.api.Configurations
{
    public static class DIConfig
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IErros, Erros>();
            services.AddScoped<IReceitaRep, ReceitaRep>();
            services.AddScoped<IReceitaService, ReceitaService>();
            // services.AddScoped<IUsuarioRep, UsuarioRep>();

            return services;
        }
    }
}
