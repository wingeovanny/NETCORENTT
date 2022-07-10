using ntt.micros.core.cuentas.domain.entities.cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.interfaces.repositories
{
    public interface IClienteRestRepository
    {
        Task<List<ClienteResponse>> ConsultaClientes();
        Task<ClienteResponse> ConsultaClienteID(string identificacion);
        Task<ClienteResponse> CrearCliente(ClienteRequest request);
        Task<ClienteResponse> EliminarCliente(string identificacion);
        Task<ClienteRequest> ActualizarCliente(ClienteRequest request);

    }
}
