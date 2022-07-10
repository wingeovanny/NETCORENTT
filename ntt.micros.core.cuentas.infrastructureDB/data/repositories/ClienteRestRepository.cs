using AutoMapper;
using ntt.micros.core.cuentas.applicationDB.models.exeptions;
using ntt.micros.core.cuentas.domainDB.entites;
using ntt.micros.core.cuentas.infrastructureDB.data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ntt.micros.core.cuentas.applicationDB.interfaces.repositories;

namespace ntt.micros.core.cuentas.infrastructureDB.data.repositories
{
    internal class ClienteRestRepository : IClienteRestRepository
    {

        private readonly DataContextDB _context;
        private readonly IMapper _mapper;
        public ClienteRestRepository(DataContextDB context, IMapper Mapper)
        {
            _context = context;
            _mapper = Mapper;
        }

        public async Task<List<Cliente>> ConsultaClientesID()
        {
            var user = await _context.Clientes.ToListAsync();

            return _mapper.Map<List<Cliente>>(user);
        }
        public async Task<Cliente> ConsultaClienteID(string identificacion)
        {
            var user = await _context.Clientes.FirstOrDefaultAsync(x => x.Identificacion == identificacion);

            if (user == null)
            {
                throw new BaseCustomException("Transaccion exisota", "Cliente no existe", 200);
            }
            return _mapper.Map<Cliente>(user);            
        }

        public async Task<Cliente> CrearCliente(Cliente value)
        {
         
            if (value.Id == 0)
            {
                
                _context.Entry(value).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
            else
            {
                var entity = await _context.Clientes.FindAsync(value.Id);
                
                if (entity == null)
                {
                    throw new BaseCustomException("", "No se encuentra el cliente para actualizar", 400);
                }

                if (_context.Clientes.Any(x => x.Identificacion == value.Identificacion))
                {
                    throw new BaseCustomException("", "Cliente ya existe", 400);
                }

                _context.Entry(entity).CurrentValues.SetValues(value);
            }

           // await _context.SaveChangesAsync();
           
            return value;

        }

        public async Task<Cliente> CrearCuenta(Cliente value)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                Cuenta cuenta = value.Cuentas.FirstOrDefault();

                if (cuenta != null && cuenta.Id == 0)
                {
                    _context.Entry(cuenta).State = EntityState.Added;
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new BaseCustomException("", "No se encuentra el datos para crea la cuenta ", 400);
                }
               
            }
            catch (Exception ex)
            {

                throw new BaseCustomException(ex.Message, ex.StackTrace, ex.GetHashCode());
            }

           
            return value;

        }

     

    }
}
