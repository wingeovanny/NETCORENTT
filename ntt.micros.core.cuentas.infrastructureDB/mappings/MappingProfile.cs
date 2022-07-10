using AutoMapper;
using ntt.micros.core.cuentas.domainDB.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructureDB.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, Cliente>();
              //.ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))              
              //.ForMember(dest => dest, source => source.MapFrom(src => src));
        }
    }
}
