using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domain.entities.cuenta
{
    public class CuentaRequest
    {
        public string? NumeroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public double? SaldoInicial { get; set; }
        public bool? Estado { get; set; }
        public string? NombreCliente { get; set; }

    }
}
