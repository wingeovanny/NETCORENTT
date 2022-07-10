using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domainDB.entites
{
    public class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int Id { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public string TipoCuenta { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int? ClienteId { get; set; }
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
