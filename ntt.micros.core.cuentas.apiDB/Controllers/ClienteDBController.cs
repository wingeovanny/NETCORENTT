using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ntt.micros.core.cuentas.applicationDB.interfaces.services;
using ntt.micros.core.cuentas.applicationDB.models.dto;
using ntt.micros.core.cuentas.domainDB.entites;
using System.ComponentModel.DataAnnotations;

namespace ntt.micros.core.cuentas.apiDB.Controllers
{
    
    [ApiController]
    public class ClienteDBController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDBController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpGet]
        [Route("clientes/consulta-cliente")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<Cliente>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<Cliente>>> ConsultaClienteID([FromHeader][Required] string identificacion)

        {
            Cliente _response = await _clienteRepository.ConsultaClienteID(identificacion);
            return Ok(new MsDtoResponse<Cliente>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

        [HttpGet]
        [Route("clientes/consulta-clientes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<Cliente>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<List<Cliente>>>> ConsultaClientesID()
        {
            List<Cliente>_response = await _clienteRepository.ConsultaClientesID();
            return Ok(new MsDtoResponse<List<Cliente>>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }



        [HttpPost]
        [Route("clientes/crear-cliente")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<Cliente>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<Cliente>>> CrearCliente([FromBody][Required] Cliente request)

        {
            Cliente _response = await _clienteRepository.CrearCliente(request);
            return Ok(new MsDtoResponse<Cliente>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

        [HttpPost]
        [Route("clientes/crear-cuenta")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<Cliente>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<Cliente>>> CrearCuenta([FromBody][Required] Cliente request)

        {
            Cliente _response = await _clienteRepository.CrearCuenta(request);
            return Ok(new MsDtoResponse<Cliente>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

    }
}
