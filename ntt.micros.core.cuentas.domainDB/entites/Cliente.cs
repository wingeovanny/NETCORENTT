using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domainDB.entites
{
    public partial class Cliente : Persona
    {
        public Cliente()
        {
            Cuentas = new HashSet<Cuenta>();
        }

        public int Id { get; set; }
        public string Contrasenia { get; set; } = null!;
        public bool Estado { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
