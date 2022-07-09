using ntt.micros.core.cuentas.domain.entities.cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.interfaces.services
{
    public interface IClienteRepository
    {
        Task<ClienteResponse> ConsultaCliente(string identificacion);
    }
}
