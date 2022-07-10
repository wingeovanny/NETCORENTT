using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.domain.entities.movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.application.services
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly IMovimientoRestRepository _imovimientoRestRepository;

        public MovimientoRepository(IMovimientoRestRepository imovimientoRestRepository)
        {
            _imovimientoRestRepository = imovimientoRestRepository;
        }

        public async Task<MovimientoResponse> ActualizarMovimiento(MovimientoResponse request)
        {
            return await _imovimientoRestRepository.ActualizarMovimiento(request);
        }

        public async Task<List<MovimientoResponse>> ConsultaMovimientoFecha(DateTime fechaInicio)
        {
            return await _imovimientoRestRepository.ConsultaMovimientoFecha(fechaInicio);
        }

        public async Task<List<MovimientoResponse>> ConsultaMovimientos(string numeroCuenta)
        {
            return await _imovimientoRestRepository.ConsultaMovimientos(numeroCuenta);
        }

        public async Task<List<MovimientoResponse>> ConsultaMovimientoUsuario(string codigoUsuario)
        {
            return await _imovimientoRestRepository.ConsultaMovimientoUsuario(codigoUsuario);
        }

        public async Task<MovimientoResponse> CrearMovimiento(MovimientoRequest request)
        {
            return await _imovimientoRestRepository.CrearMovimiento(request);
        }

        public async Task<MovimientoResponse> EliminarMovimiento(string numeroCuenta, int idMovimiento)
        {
            return await _imovimientoRestRepository.EliminarMovimiento(numeroCuenta, idMovimiento);
        }
    }
}
