using ntt.micros.core.cuentas.domain.entities.cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.interfaces.services
{
    public interface ICuentaRepository
    {
        Task<List<CuentaResponse>> ConsultaCuentas();
        Task<CuentaResponse> ConsultaCuentaID(string numeroCuenta);
        Task<CuentaResponse> CrearCuenta(CuentaRequest request);
        Task<CuentaResponse> EliminarCuenta(string numeroCuenta);
        Task<CuentaRequest> ActualizarCuenta(CuentaRequest request);



    }
}
