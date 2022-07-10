using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.models.exeptions;
using ntt.micros.core.cuentas.domain.entities.cuenta;
using ntt.micros.core.cuentas.infrastructure.data.Context;

namespace ntt.micros.core.cuentas.infrastructure.data.repositories
{
    public class CuentaRestRepository: ICuentaRestRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CuentaRestRepository(DataContext context, IMapper Mapper)
        {
            _context = context;
            _mapper = Mapper;
        }

        public async Task<CuentaRequest> ActualizarCuenta(CuentaRequest request)
        {
            var entity = await _context.Cuentas.FirstOrDefaultAsync(x => x.NumeroCuenta == request.NumeroCuenta);


            if (entity != null)
            {
                entity.SaldoInicial = request.SaldoInicial;
                entity.Estado = request.Estado;
                entity.TipoCuenta = request.TipoCuenta;
                _context.Entry(entity).State = EntityState.Modified;

                _context.Entry(entity).CurrentValues.SetValues(request);
                await _context.SaveChangesAsync();
            }
            else
            {

                throw new BaseCustomException("No existe cliente para actualizar", "", 400);

            }

            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<CuentaResponse> ConsultaCuentaID(string numeroCuenta)
        {
            Cuenta user = await _context.Cuentas.FirstOrDefaultAsync(x => x.NumeroCuenta == numeroCuenta);

            if (user == null)
            {
                throw new BaseCustomException("Transaccion exisota", "Cliente no existe", 200);
            }

            var clientesResult = _mapper.Map<CuentaResponse>(user);

            return clientesResult;
        }

        public async Task<List<CuentaResponse>> ConsultaCuentas(string identificacion)
        {
            List<Cuenta> user = await _context.Cuentas.ToListAsync();// Where(x=> x.NumeroCuenta == identificacion);

            var clientesResult = _mapper.Map<List<CuentaResponse>>(user);

            return clientesResult.Where(x=> x.NombreCliente == identificacion).ToList();
        }

        public async Task<CuentaResponse> CrearCuenta(CuentaRequest request)
        {
            if (_context.Cuentas.Any(x => x.NumeroCuenta == request.NumeroCuenta))
            {
                throw new BaseCustomException("", "Cliente ya existe", 400);
            }

            CuentaResponse dato = new CuentaResponse();
            // map model to new user object
            var cuenta = _mapper.Map<Cuenta>(request);

            // save user
            _context.Cuentas.Add(cuenta);
            _context.SaveChanges();


            await _context.SaveChangesAsync();

            return dato = _mapper.Map<CuentaResponse>(cuenta);
        }

        public async Task<CuentaResponse> EliminarCuenta(string numeroCuenta)
        {
            var entity = await _context.Cuentas.FirstOrDefaultAsync(x => x.NumeroCuenta == numeroCuenta);

            CuentaResponse dato = new CuentaResponse();
            if (entity != null)
            {
                var cta = getCta(Convert.ToInt32(entity.Id));
                _context.Cuentas.Remove(cta);
                _context.SaveChanges();

            }
            else
            {
                throw new BaseCustomException("", "Cuenta no existe", 400);
            }

            return dato;
        }


        private Cuenta getCta(int id)
        {
            var cuenta = _context.Cuentas.Find(id);
            return cuenta;
        }
    }
}
