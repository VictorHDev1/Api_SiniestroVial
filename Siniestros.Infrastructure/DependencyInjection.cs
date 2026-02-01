using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siniestros.Application.Interfaces;
using Siniestros.Infrastructure.Persistence;
using Siniestros.Infrastructure.Persistence.Repositories;

namespace Siniestros.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
          
            services.AddDbContext<SiniestrosDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Repositorios
            services.AddScoped<ISiniestroRepository, SiniestroRepository>();
            services.AddScoped<ISiniestroReadRepository, SiniestroReadRepository>();

            return services;
        }
    }
}
