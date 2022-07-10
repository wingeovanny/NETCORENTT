using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domain.entities.cliente
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Genero { get; set; }
        public int? Edad { get; set; }
        public string? Contrasenia { get; set; }
        public bool? Estado { get; set; }
    }
}
