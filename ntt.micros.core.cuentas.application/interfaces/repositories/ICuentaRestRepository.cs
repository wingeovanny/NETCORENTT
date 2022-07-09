using ntt.micros.core.cuentas.domain.entities.cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.interfaces.repositories
{
    public interface ICuentaRestRepository
    {
        Task<CuentaResponse> ConsultaCuenta(string cuenta);
    }
}
