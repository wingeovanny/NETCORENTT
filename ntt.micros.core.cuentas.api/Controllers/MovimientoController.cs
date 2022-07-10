using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.application.models.dto;
using ntt.micros.core.cuentas.domain.entities.movimiento;
using System.ComponentModel.DataAnnotations;

namespace ntt.micros.core.cuentas.api.Controllers
{
   
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoRepository _movimientoRepository;
        public MovimientoController(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;   
        }

        [HttpGet]
        [Route("movimientos/consulta-movimientos-fecha")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<MovimientoResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<List<MovimientoResponse>>>> ConsultaMovimientoFecha([FromHeader][Required] DateTime fechaInicio)

        {
           List<MovimientoResponse> _response = await _movimientoRepository.ConsultaMovimientoFecha(fechaInicio);
            return Ok(new MsDtoResponse<List<MovimientoResponse>>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

        [HttpGet]
        [Route("movimientos/consulta-movimientos-cuenta")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<MovimientoResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<List<MovimientoResponse>>>> ConsultaMovimientos([FromHeader][Required] string numeroCuenta)

        {
            List<MovimientoResponse> _response = await _movimientoRepository.ConsultaMovimientos(numeroCuenta);
            return Ok(new MsDtoResponse<List<MovimientoResponse>>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }



        [HttpPost]
        [Route("clientes/crear-movimiento")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<MovimientoResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<MovimientoResponse>>> CrearMovimiento([FromBody][Required] MovimientoRequest request)

        {
            MovimientoResponse _response = await _movimientoRepository.CrearMovimiento(request);
            return Ok(new MsDtoResponse<MovimientoResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpPut]
        [Route("clientes/actualizar-movimiento")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<MovimientoResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<MovimientoResponse>>> ActualizarMovimiento([FromBody][Required] MovimientoResponse request)

        {
            MovimientoResponse _response = await _movimientoRepository.ActualizarMovimiento(request);
            return Ok(new MsDtoResponse<MovimientoResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpDelete]
        [Route("clientes/eliminar-movimiento")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<MovimientoResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<MovimientoResponse>>> EliminarMovimiento([FromHeader][Required] string numeroCuenta, int idMovimiento)

        {
            MovimientoResponse _response = await _movimientoRepository.EliminarMovimiento(numeroCuenta, idMovimiento);
            return Ok(new MsDtoResponse<MovimientoResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));

        }

    }
}
