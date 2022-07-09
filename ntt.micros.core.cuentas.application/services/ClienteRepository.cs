using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.domain.entities.cliente;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.services
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IClienteRestRepository _clienteRestRespository;
        
        public ClienteRepository(IClienteRestRepository clienteRestRespository )
        {
            _clienteRestRespository = clienteRestRespository;            
        }

        public async Task<ClienteResponse> ConsultaClienteID(string identificacion)
        {
            return  await _clienteRestRespository.ConsultaClienteID(identificacion);

        }

        public async Task<List<ClienteResponse>> ConsultaClientes()
        {
            return  await _clienteRestRespository.ConsultaClientes();
        }

        public async Task<ClienteRequest> ActualizarCliente(ClienteRequest request)
        {
            return await _clienteRestRespository.ActualizarCliente(request);
        }
        public async Task<ClienteResponse> CrearCliente(ClienteRequest request)
        {
            return await _clienteRestRespository.CrearCliente(request);
        }

        public  int EliminarCliente(string identificacion)
        {
            return  _clienteRestRespository.EliminarCliente(identificacion);
        }
    }
}
