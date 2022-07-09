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
        public ClienteRepository(IClienteRestRepository clienteRestRespository)
        {
            _clienteRestRespository = clienteRestRespository;   
        }
        public async Task<ClienteResponse> ConsultaCliente(string identificacion)
        {
            return await _clienteRestRespository.ConsultaCliente(identificacion);
        }
    }
}
