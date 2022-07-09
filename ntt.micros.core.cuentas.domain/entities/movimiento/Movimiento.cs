using ntt.micros.core.cuentas.domain.entities.cuenta;

namespace ntt.micros.core.cuentas.domain.entities.movimiento
{
    public class Movimiento
    {
        public int MovimientoID { get; set; }
        public DateTime FechaMovimento { get; set; }
        public string? TipoMovimiento { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }
        public Cuenta? CuentaBancaria { get; set; }

    }
}
