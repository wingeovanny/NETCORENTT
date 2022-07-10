using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domain.entities.movimiento
{
    public class MovimientoRequest
    {
        public string? NumeroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public string? Estado { get; set; }
        public string? DescripcionMovimiento { get; set; }


      
    }
}
