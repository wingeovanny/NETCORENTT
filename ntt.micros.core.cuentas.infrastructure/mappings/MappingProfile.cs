using System;
using System.Collections.Generic;
using System.Linq;
using ntt.micros.core.cuentas.domain.entities.movimiento;
using AutoMapper;
using System.Threading.Tasks;
using ntt.micros.core.cuentas.domain.entities;
using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.domain.entities.cuenta;

namespace ntt.micros.core.cuentas.infrastructure.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            // ClienteRequest -> Cliente
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<Cliente, ClienteResponse>();
            CreateMap<ClienteRequest, ClienteResponse>();


            // CuentaRequest -> Cuenta
            CreateMap<CuentaRequest, Cuenta>();
            CreateMap<Cuenta, CuentaResponse>();


            // ClienteRequest -> Cliente
            CreateMap<MovimientoRequest, Movimiento>();
            CreateMap<Movimiento, MovimientoResponse>();
            

        }

    }
}
