using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using ntt.micros.core.cuentas.domain.entities;

namespace ntt.micros.core.cuentas.infrastructure.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateRequest -> User
            CreateMap<CreateRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                    // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));
        }

    }
}
