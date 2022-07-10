using Microsoft.AspNetCore.Mvc;

namespace ntt.micros.core.cuentas.apiDB.Extentions
{
    public static class ServiceExtentions
    {

        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(2, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            return services;

        }

    }
}
