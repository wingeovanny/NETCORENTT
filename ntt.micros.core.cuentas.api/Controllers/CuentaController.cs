using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.application.models.dto;
using ntt.micros.core.cuentas.domain.entities.cuenta;
using ntt.micros.core.cuentas.infrastructure.data.Context;
using System.ComponentModel.DataAnnotations;


namespace ntt.micros.core.cuentas.api.Controllers
{
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;
      
        public CuentaController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;         
        }

        /// <summary>
        /// Metodo que permite consultar los datos de una cuenta en base al numero ingresado.
        /// </summary>
        /// <param name="cuenta">Numero de Cuenta</param>
       
        [HttpGet]
        [Route("cuentas/consulta-cuenta")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<CuentaResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<CuentaResponse>>> ConsultaCuentaID([FromHeader][Required] string cuenta)

        {
            CuentaResponse _response = await _cuentaRepository.ConsultaCuentaID(cuenta);
            return Ok(new MsDtoResponse<CuentaResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

        [HttpGet]
        [Route("clientes/consulta-cuentas")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<CuentaResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<List<CuentaResponse>>>> ConsultaCuentas([FromHeader][Required] string identificacion)

        {
            List<CuentaResponse> _response = await _cuentaRepository.ConsultaCuentas(identificacion);
            return Ok(new MsDtoResponse<List<CuentaResponse>>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpPost]
        [Route("clientes/crear-cuenta")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<CuentaResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<CuentaResponse>>> CrearCuenta([FromBody][Required] CuentaRequest request)

        {
            CuentaResponse _response = await _cuentaRepository.CrearCuenta(request);
            return Ok(new MsDtoResponse<CuentaResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpPut]
        [Route("clientes/actualizar-cuenta")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<CuentaRequest>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<CuentaRequest>>> ActualizarCliente([FromBody][Required] CuentaRequest request)

        {
            CuentaRequest _response = await _cuentaRepository.ActualizarCuenta(request);
            return Ok(new MsDtoResponse<CuentaRequest>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpDelete]
        [Route("clientes/eliminar-cuenta")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<CuentaResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<CuentaResponse>>> EliminarCuenta([FromHeader][Required] string identificacion)

        {
            CuentaResponse _response = await _cuentaRepository.EliminarCuenta(identificacion);
            return Ok(new MsDtoResponse<CuentaResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));

        }

    }
}
