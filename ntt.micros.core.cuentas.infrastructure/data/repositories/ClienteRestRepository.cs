using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.infrastructure.data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ntt.micros.core.cuentas.application.models.exeptions;

namespace ntt.micros.core.cuentas.infrastructure.data.repositories
{
    public class ClienteRestRepository : IClienteRestRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ClienteRestRepository(DataContext context, IMapper Mapper)
        {
            _context = context;
            _mapper = Mapper;
        }


        public async Task<ClienteResponse> ConsultaClienteID(string identificacion)
        {
            
            Cliente user = await _context.Clientes.FirstOrDefaultAsync(x=> x.Identificacion == identificacion);// .FirstOrDefault(x => x.Identificacion == identificacion);

            if (user == null) throw new KeyNotFoundException("User not found");

            var clientesResult = _mapper.Map<ClienteResponse>(user);

            return clientesResult;
        }

        public async Task<List<ClienteResponse>> ConsultaClientes()
        {
            List<Cliente> user = await _context.Clientes.ToListAsync();


            var clientesResult = _mapper.Map<List<ClienteResponse>>(user);

            return clientesResult; 
           
        }

        public async Task<ClienteRequest> ActualizarCliente(ClienteRequest request)
        {
            var entity = await _context.Clientes.FirstOrDefaultAsync(x => x.Identificacion == request.Identificacion);


            if (entity != null)
            {
                entity.Nombre = request.Nombre;
                entity.Telefono = request.Telefono;
                entity.Direccion = request.Direccion;
                entity.Edad = request.Edad;
                _context.Entry(entity).State = EntityState.Modified;

                _context.Entry(entity).CurrentValues.SetValues(request);
                await _context.SaveChangesAsync();
            }else
            {
                
                    throw new BaseCustomException("no existe cliente para actualizar", "",400);
                
            }

            await _context.SaveChangesAsync();

            return request;
        }



        public async Task<ClienteResponse> CrearCliente(ClienteRequest request)
        {
               if (_context.Clientes.Any(x => x.Identificacion == request.Identificacion))
                {
                throw new BaseCustomException("", "Cliente ya existe", 400);
                }

                ClienteResponse dato = new ClienteResponse();
                // map model to new user object
                var user = _mapper.Map<Cliente>(request);

                // var entity = await _context.Clientes.FindAsync(request.Identificacion);

                // save user
                _context.Clientes.Add(user);
                _context.SaveChanges();


                await _context.SaveChangesAsync();
        
            return dato;

        }
         public int EliminarCliente(string identificacion)
        {
            int result = 0;
            var cliente = getUser(identificacion);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            result = 1;

            return  result;
            
        }


        // helper methods

        private Cliente getUser(string identificacion)
        {
            var user = _context.Clientes.Find(identificacion);
            if (user == null) throw new KeyNotFoundException("Cliente no existe");
            return user;
        }

    }
}
