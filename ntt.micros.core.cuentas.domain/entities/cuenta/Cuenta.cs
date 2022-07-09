using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.domain.entities.movimiento;

namespace ntt.micros.core.cuentas.domain.entities.cuenta
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public double? SaldoInicial { get; set; }
        public string? Estado { get; set; }
        public Cliente? Cliente { get; set; }
        
    }
}
