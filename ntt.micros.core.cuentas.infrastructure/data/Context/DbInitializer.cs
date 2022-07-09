using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.domain.entities.cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructure.data.Context
{
    public static class DbInitializer
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Agregando Artistas a la BD
                if (_context.Clientes.Any())
                {
                    return;
                }

                _context.Clientes.AddRange(
                    new Cliente { Nombre = "Luis" },
                    new Cliente { Nombre = "Ricardo" },
                    new Cliente { Nombre = "Kalimba" }
                 );

                _context.SaveChanges();


                // Agregando Albumes a la BD
                if (_context.Cuentas.Any())
                {
                    return;
                }

                _context.Cuentas.AddRange(
                    new Cuenta
                    {
                        CuentaID = _context.Clientes.FirstOrDefault(a => a.Nombre.Equals("Luis")).ClienteID,
                       NumeroCuenta ="",
                       SaldoInicial = 123,
                       Estado ="A"
                    },

                    new Cuenta
                    {
                        CuentaID = _context.Clientes.FirstOrDefault(a => a.Nombre.Equals("Ricardo")).ClienteID,
                        NumeroCuenta = "",
                        SaldoInicial = 456,
                        Estado = "B"
                    },

                    new Cuenta
                    {
                        CuentaID = _context.Clientes.FirstOrDefault(a => a.Nombre.Equals("Ricardo")).ClienteID,
                        NumeroCuenta = "",
                        SaldoInicial = 789,
                        Estado = "C"
                    }
                   
                );

                _context.SaveChanges();
            }
        }
    }
}
