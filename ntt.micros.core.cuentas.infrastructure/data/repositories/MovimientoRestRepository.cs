using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.application.interfaces.repositories;
using ntt.micros.core.cuentas.application.models.exeptions;
using ntt.micros.core.cuentas.domain.entities.movimiento;
using ntt.micros.core.cuentas.infrastructure.data.Context;

namespace ntt.micros.core.cuentas.infrastructure.data.repositories
{
    public class MovimientoRestRepository : IMovimientoRestRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MovimientoRestRepository(DataContext context, IMapper Mapper)
        {
            _context = context;
            _mapper = Mapper;
        }

        public async Task<MovimientoResponse> ActualizarMovimiento(MovimientoResponse request)
        {
            var entity = await _context.Movimientos.FirstOrDefaultAsync(x => x.Id == request.Id);


            if (entity != null)
            {
                entity.TipoMovimiento = request.TipoCuenta;
                entity.Saldo = request.SaldoInicial;
                entity.FechaMovimento = DateTime.Now;
                _context.Entry(entity).State = EntityState.Modified;

                _context.Entry(entity).CurrentValues.SetValues(request);
                await _context.SaveChangesAsync();
            }
            else
            {

                throw new BaseCustomException("No existe movimiento para actualizar", "", 400);

            }

            await _context.SaveChangesAsync();

            return request;
        }

      

        public async Task<List<MovimientoResponse>> ConsultaMovimientoFecha(DateTime fechaInicio)
        {
            List<Movimiento> mov = await _context.Movimientos.ToListAsync();

            var movResult = _mapper.Map<List<MovimientoResponse>>(mov);

            return movResult.Where(x => x.FechaMovimento >= fechaInicio).ToList();
        }

        public async Task<List<MovimientoResponse>> ConsultaMovimientos(string numeroCuenta)
        {
            List<Movimiento> mov = await _context.Movimientos.ToListAsync();

            var movResult = _mapper.Map<List<MovimientoResponse>>(mov);

            return movResult.Where(x => x.NumeroCuenta == numeroCuenta).ToList();
        }

        public async Task<List<MovimientoResponse>> ConsultaMovimientoUsuario(string codigoUsuario)
        {
            List<Movimiento> mov = await _context.Movimientos.ToListAsync();

            var movResult = _mapper.Map<List<MovimientoResponse>>(mov);

            return movResult.Where(x => x.Estado == codigoUsuario).ToList();
        }

        public async Task<MovimientoResponse> CrearMovimiento(MovimientoRequest request)
        {

            MovimientoResponse dato = new();
           
            var mov = _mapper.Map<Movimiento>(request);
            mov.FechaMovimento = DateTime.Now;
            _context.Movimientos.Add(mov);
            _context.SaveChanges();

            await _context.SaveChangesAsync();

            dato = _mapper.Map<MovimientoResponse>(mov);

            dato.SaldoInicial = request.SaldoInicial;
            dato.NumeroCuenta = request.NumeroCuenta;

            return dato;
        }

        public async Task<MovimientoResponse> EliminarMovimiento(string numeroCuenta, int idMovimiento)
        {
            var entity = await _context.Movimientos.FirstOrDefaultAsync(x => x.Id == idMovimiento);

            MovimientoResponse dato = new();
            if (entity != null)
            {
                var cta = getMov(Convert.ToInt32(entity.Id));
                _context.Movimientos.Remove(entity);
                _context.SaveChanges();

            }
            else
            {
                throw new BaseCustomException("", "Movimiento no existe", 400);
            }

            return dato;
        }

        private Movimiento getMov(int id)
        {
            var movimiento = _context.Movimientos.Find(id);
            return movimiento;
        }
    }
}
