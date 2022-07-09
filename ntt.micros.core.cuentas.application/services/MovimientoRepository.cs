using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.domain.entities.movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.services
{
    public class MovimientoRepository : IMovimientoRepository
    {
        public Task<List<MovimientoResponse>> ConsultaMovimientoFecha(string fechaInicio)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovimientoResponse>> ConsultaMovimientoUsuario(string codigoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
