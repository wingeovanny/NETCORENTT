
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
        [Route("clientes/consulta-clientes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<ClienteResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<List<ClienteResponse>>>> ConsultaClientes()

        {
           List<ClienteResponse> _response = await _clienteRepository.ConsultaClientes();
            return Ok(new MsDtoResponse<List<ClienteResponse>>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }

        [HttpGet]
        [Route("clientes/consulta-cliente")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<ClienteResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<ClienteResponse>>> ConsultaClienteID([FromHeader][Required] string identificacion)

        {
            ClienteResponse _response = await _clienteRepository.ConsultaClienteID(identificacion);
            return Ok(new MsDtoResponse<ClienteResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpPost]
        [Route("clientes/crear-cliente")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<ClienteResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<ClienteResponse>>> CrearCliente([FromBody][Required] ClienteRequest request)

        {
            ClienteResponse _response = await _clienteRepository.CrearCliente(request);
            return Ok(new MsDtoResponse<ClienteResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpPut]
        [Route("clientes/actualizar-cliente")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<ClienteRequest>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<ClienteRequest>>>ActualizarCliente([FromBody][Required] ClienteRequest request)

        {
            ClienteRequest _response = await _clienteRepository.ActualizarCliente(request);
            return Ok(new MsDtoResponse<ClienteRequest>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
        }


        [HttpDelete]
        [Route("clientes/eliminar-cliente")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(MsDtoResponse<ClienteResponse>), 200)]
        [ProducesResponseType(typeof(MsDtoResponseError), 400)]
        [ProducesResponseType(typeof(MsDtoResponseError), 500)]
        public async Task<ActionResult<MsDtoResponse<ClienteResponse>>> EliminarCliente([FromHeader][Required] string identificacion)

        {
            ClienteResponse _response = await  _clienteRepository.EliminarCliente(identificacion);
             return Ok(new MsDtoResponse<ClienteResponse>(_response, HttpContext?.TraceIdentifier.Split(":")[0].ToLower()));
          
        }
    }


}
