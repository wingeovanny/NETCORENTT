using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.domain.entities.movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructure.data.repositories
{
    public class MovimientoRestRepository : IMovimientoRestRepository
    {
        public async Task<List<MovimientoResponse>> ConsultaMovimientoUsuario(string codigoUsuario)
        {
            List<MovimientoResponse> lista = new List<MovimientoResponse>();

            MovimientoResponse result = new()
            {
                NumeroCuenta = "1221212"
            };

            lista.Add(result);

            return lista;

        }

        public async Task<List<MovimientoResponse>> ConsultaMovimientoFecha(string fechaInicio)
        {
            List<MovimientoResponse> lista = new List<MovimientoResponse>();

            MovimientoResponse result = new()
            {
                NumeroCuenta = "12"
            };

            lista.Add(result);

            return lista;

        }


    }
}
