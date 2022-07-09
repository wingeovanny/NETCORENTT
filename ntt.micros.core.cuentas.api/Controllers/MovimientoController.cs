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
        public async Task<ActionResult<MsDtoResponse<List<MovimientoResponse>>>> ConsultaMovimientoFecha([FromHeader][Required] string fechaInicio)

        {
           List<MovimientoResponse> _response = await _movimientoRepository.ConsultaMovimientoFecha(fechaInicio);
            return Ok(new MsDtoResponse<List<MovimientoResponse>>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

    }
}
