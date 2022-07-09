using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.infrastructure.data.repositories;
using Serilog;
using System.Reflection;

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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICuentaRestRepository, CuentaRestRepository>();

            return services;


        }
    }
}
