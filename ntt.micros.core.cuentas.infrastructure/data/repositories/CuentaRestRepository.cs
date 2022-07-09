using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.domain.entities.cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructure.data.repositories
{
    public class CuentaRestRepository: ICuentaRestRepository
    {
        public async Task<CuentaResponse> ConsultaCuenta(string cuenta)
        {
            CuentaResponse result = new()
            {
                Estado = true,
                SaldoInicial = 12
            };

            return result;
        }
    }
}
