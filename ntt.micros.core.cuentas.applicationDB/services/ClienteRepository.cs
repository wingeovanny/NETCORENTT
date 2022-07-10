using ntt.micros.core.cuentas.applicationDB.interfaces.repositories;
using ntt.micros.core.cuentas.applicationDB.interfaces.services;
using ntt.micros.core.cuentas.domainDB.entites;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.applicationDB.services
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IClienteRestRepository _clienteRestRespository;
        
        public ClienteRepository(IClienteRestRepository clienteRestRespository )
        {
            _clienteRestRespository = clienteRestRespository;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        public async Task<Cliente> ConsultaClienteID(string identificacion)
        {
            return await _clienteRestRespository.ConsultaClienteID(identificacion);
        }

        public async Task<List<Cliente>> ConsultaClientesID()
        {
            return await _clienteRestRespository.ConsultaClientesID();
        }

        public async Task<Cliente> CrearCliente(Cliente value)
        {
            return await _clienteRestRespository.CrearCliente(value);
        }

        public async Task<Cliente> CrearCuenta(Cliente value)
        {
            return await _clienteRestRespository.CrearCuenta(value);
        }
    }
}
