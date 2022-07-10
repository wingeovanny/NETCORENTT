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

        public async Task<CuentaRequest> ActualizarCuenta(CuentaRequest request)
        {
            return await _icuentaRestRepository.ActualizarCuenta(request);
        }

        public async Task<CuentaResponse> ConsultaCuentaID(string numeroCuenta)
        {
            return await _icuentaRestRepository.ConsultaCuentaID(numeroCuenta);
        }

        public async Task<List<CuentaResponse>> ConsultaCuentas()
        {
            return await _icuentaRestRepository.ConsultaCuentas();
        }

        public async Task<CuentaResponse> CrearCuenta(CuentaRequest request)
        {
            return await _icuentaRestRepository.CrearCuenta(request);
        }

        public async Task<CuentaResponse> EliminarCuenta(string numeroCuenta)
        {
            return await _icuentaRestRepository.EliminarCuenta(numeroCuenta);
        }
    }
}
