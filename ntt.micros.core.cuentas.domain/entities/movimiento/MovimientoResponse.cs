
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domain.entities.movimiento
{
    public class MovimientoResponse
    {
        public int Id { get; set; }
        public DateTime FechaMovimento { get; set; }
        public string? NombreCliente { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public string? Estado { get; set; }
        public double Movimiento { get; set; }
        public double SaldoDisponible { get; set; }
        
    }
}
