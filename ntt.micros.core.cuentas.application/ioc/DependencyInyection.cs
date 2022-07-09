using Microsoft.Extensions.DependencyInjection;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.application.services;

namespace ntt.micros.core.cuentas.application.ioc
{
    public static class DependencyInyection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
