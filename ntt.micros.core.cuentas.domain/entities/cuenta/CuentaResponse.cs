using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domain.entities.cuenta
{
    public class CuentaResponse
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string? Cliente { get; set; }
        public string? NumeroCuenta { get; set; }
    }
}
