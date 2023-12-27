using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SorteioHabitacao.Infra.Data;
using Microsoft.EntityFrameworkCore;
using SorteioHabitacao.Domain.Repository;
using SorteioHabitacao.Infra.Repository;

namespace SorteioHabitacao.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastrutureService
            (this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<SorteadoDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
            //        throw new InvalidOperationException("connection string not found"))

                 services.AddDbContext<SorteadoDbContext>(options =>
                options.UseSqlServer("Server =DESKTOP-BIJDUI6; Database= SorteioHabitacao2; Trusted_Connection = True;TrustServerCertificate=true") 
                   
          );
            services.AddTransient<ISorteadoRepository, SorteadoRepository>();
            return services;
        }
    }
}
