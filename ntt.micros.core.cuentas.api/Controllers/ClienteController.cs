
using Microsoft.AspNetCore.Mvc;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.application.models.dto;
using ntt.micros.core.cuentas.domain.entities.cliente;
using System.ComponentModel.DataAnnotations;

namespace ntt.micros.core.cuentas.api.Controllers
{
   
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository; 
        }

        [HttpGet]
        [Route("clientes/consulta-cliente")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<ClienteResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<ClienteResponse>>> ConsultaCliente([FromHeader][Required] string identificacion)

        {
            ClienteResponse _response = await _clienteRepository.ConsultaCuenta(identificacion);
            return Ok(new MsDtoResponse<ClienteResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }
    }


}
