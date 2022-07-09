using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ntt.micros.core.cuentas.domain.entities.cuenta;

namespace ntt.micros.core.cuentas.domain.entities.cliente
{
    public class Cliente : Persona
    {
        public int ClienteID { get; set; }
        public int CuentaID { get; set; }


        public string? Contraseña { get; set; }  
        
        public string? Estado { get; set; }    

    }
}
