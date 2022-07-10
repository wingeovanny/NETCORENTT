using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.infrastructure.data.repositories;
using Serilog;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.infrastructure.data.Context;

namespace ntt.micros.core.cuentas.infrastructure.ioc
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                 .ReadFrom
                 .Configuration(configuration).CreateLogger();

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));


            //var builderConnection = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));
            //builderConnection.Password = string.IsNullOrEmpty(configuration["ClaveBase"]) ? String.Empty : configuration["ClaveBase"];

            services.AddDbContext<DataContext>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICuentaRestRepository, CuentaRestRepository>();
            services.AddScoped<IClienteRestRepository, ClienteRestRepository>();
            services.AddScoped<IMovimientoRestRepository, MovimientoRestRepository>();
            

            return services;


        }
    }
}
