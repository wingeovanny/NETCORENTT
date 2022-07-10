using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.api.Controllers;
using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.interfaces.services;
using ntt.micros.core.cuentas.application.models.dto;
using ntt.micros.core.cuentas.application.services;
using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.infrastructure.data.Context;
using ntt.micros.core.cuentas.infrastructure.data.repositories;

namespace ntt.micros.core.cuentas.TestNTTData
{
    public class Testing
    {

        private readonly ClienteController _controller;
        private readonly IClienteRepository _service;
        private readonly IClienteRestRepository _restRepository;

        

        public Testing(ClienteController controller, IClienteRepository service, IClienteRestRepository restRepository)
        {
            _controller = controller;
            _service = service;
            _restRepository = restRepository;
        }

        [Fact]
        public  void ConsultaClientes_OK()
        {
            var result =   _controller.ConsultaClientes();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void ConsultaClientesIDOK()
        {
            string id = "1721436788";

            var result = _controller.ConsultaClienteID(id);

            Assert.IsType<OkObjectResult>(result);
        }

    }
}