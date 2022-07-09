using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domain.entities.movimiento
{
    public class MovimientoRequest
    {
        public DateTime FechaMovimento { get; set; }
        public string? TipoMovimiento { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }
    }
}
