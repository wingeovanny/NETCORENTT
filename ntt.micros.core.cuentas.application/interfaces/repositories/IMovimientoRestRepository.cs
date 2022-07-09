using ntt.micros.core.cuentas.domain.entities.movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.interfaces.repositories
{
    public interface IMovimientoRestRepository
    {
        Task<List<MovimientoResponse>> ConsultaMovimientoUsuario(string codigoUsuario);

        Task<List<MovimientoResponse>> ConsultaMovimientoFecha(string fechaInicio);

    }
}
