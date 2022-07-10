using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.models.exeptions;
using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.infrastructure.data.Context;

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

            if (user == null)
            {
                throw new BaseCustomException("Transaccion exisota", "Cliente no existe", 200);
            }

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
                
                    throw new BaseCustomException("No existe cliente para actualizar", "",400);
                
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

                // save user
                _context.Clientes.Add(user);
                _context.SaveChanges();


                await _context.SaveChangesAsync();
        
            return dato = _mapper.Map<ClienteResponse>(user);

        }
        public async Task<ClienteResponse> EliminarCliente(string identificacion)
        {
            
            var entity = await _context.Clientes.FirstOrDefaultAsync(x => x.Identificacion == identificacion);
          
            ClienteResponse dato = new ClienteResponse();
            if (entity!=null)
            {               
                var cliente = getUser(Convert.ToInt32(entity.Id));
                 _context.Clientes.Remove(cliente);
                _context.SaveChanges();
               
            }
            else
            {
                throw new BaseCustomException("", "Cliente no existe", 400);
            }


            return dato;
        }


        // helper methods

        private Cliente getUser(int id)
        {
            var  user = _context.Clientes.Find(id);           
            return user;
        }

    }
}
