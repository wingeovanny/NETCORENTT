using Microsoft.AspNetCore.Mvc;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.application.models.dto;
using ntt.micros.core.cuentas.domain.entities.cuenta;
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
        public async Task<ActionResult<MsDtoResponse<CuentaResponse>>> ConsultaCuenta([FromHeader][Required] string cuenta)

        {
            CuentaResponse _response = await _cuentaRepository.ConsultaCuenta(cuenta);
            return Ok(new MsDtoResponse<CuentaResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

    }
}
