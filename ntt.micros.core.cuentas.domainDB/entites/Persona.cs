using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domainDB.entites
{
    public class Persona
    {
        [JsonIgnore]
        public int PersonaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string? Direccion { get; set; }
        public string Telefono { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public int? Edad { get; set; }

       
    }
}
