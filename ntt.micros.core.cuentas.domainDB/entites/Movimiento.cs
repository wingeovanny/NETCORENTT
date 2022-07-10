using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domainDB.entites
{
    public  class Movimiento
    {
        public int Id { get; set; }
        public DateTime FechaMovimento { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public int? CuentaId { get; set; }
        public virtual Cuenta? Cuenta { get; set; }
    }
}
