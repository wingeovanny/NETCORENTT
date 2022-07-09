using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.domain.entities.cliente
{
    public class Cliente : Persona
    {        
        public string? Contraseña { get; set; }    
        public string? Estado { get; set; }    
    }
}
