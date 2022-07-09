using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.domain.entities.cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.services
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly ICuentaRestRepository _icuentaRestRepository;

        public CuentaRepository(ICuentaRestRepository icuentaRestRepository)
        {
            _icuentaRestRepository = icuentaRestRepository;
        }

        public async Task<CuentaResponse> ConsultaCuenta(string cuenta)
        {
            return await _icuentaRestRepository.ConsultaCuenta(cuenta);
        }
    }
}
