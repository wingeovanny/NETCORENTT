using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ntt.micros.core.cuentas.domain.entities.cuenta;

namespace ntt.micros.core.cuentas.domain.entities.cliente
{
    public class Cliente : Persona
    {
        public int? Id { get; set; }
        public string? Contrasenia { get; set; }
        public bool? Estado { get; set; }

    }
}
