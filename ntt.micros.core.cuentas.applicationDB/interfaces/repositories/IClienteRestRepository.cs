using ntt.micros.core.cuentas.domainDB.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.applicationDB.interfaces.repositories
{
    public interface IClienteRestRepository
    {
        Task<Cliente> CrearCuenta(Cliente value);

        Task<Cliente> CrearCliente(Cliente value);

        Task<Cliente> ConsultaClienteID(string identificacion);

        Task<List<Cliente>> ConsultaClientesID();

    }
}
