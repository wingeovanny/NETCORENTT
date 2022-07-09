using ntt.micros.core.cuentas.domain.entities.movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.interfaces.services
{
    public interface IMovimientoRepository
    {
        Task<List<MovimientoResponse>> ConsultaMovimientoUsuario(string codigoUsuario);

        Task<List<MovimientoResponse>> ConsultaMovimientoFecha(string fechaInicio);
    }
}
