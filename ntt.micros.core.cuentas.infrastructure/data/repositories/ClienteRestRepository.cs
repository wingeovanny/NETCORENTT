using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.domain.entities.cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructure.data.repositories
{
    public class ClienteRestRepository : IClienteRestRepository
    {
        public async Task<ClienteResponse> ConsultaCliente(string identificacion)
        {
            ClienteResponse result = new()
            {
                Identificacion = "12121212"
            };

            return result;

        }
    }
}
