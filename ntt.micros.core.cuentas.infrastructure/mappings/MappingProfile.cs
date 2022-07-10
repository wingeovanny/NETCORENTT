using AutoMapper;
using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.domain.entities.cuenta;
using ntt.micros.core.cuentas.domain.entities.movimiento;

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
            CreateMap<MovimientoRequest, Movimiento>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Saldo, source => source.MapFrom(src => src.SaldoInicial))
                .ForMember(dest => dest.TipoMovimiento, source => source.MapFrom(src => src.DescripcionMovimiento));

            CreateMap<Movimiento, MovimientoResponse>()
                 .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                 .ForMember(dest => dest.TipoCuenta, source => source.MapFrom(src => src.TipoMovimiento))
                 .ForMember(dest => dest.FechaMovimento, source => source.MapFrom(src => src.FechaMovimento))
                 .ForMember(dest => dest.SaldoDisponible, source => source.MapFrom(src => src.Valor));
                 








        }

    }
}
