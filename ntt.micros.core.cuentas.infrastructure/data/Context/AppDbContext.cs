using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.domain.entities;
using ntt.micros.core.cuentas.domain.entities.cliente;
using ntt.micros.core.cuentas.domain.entities.cuenta;
using ntt.micros.core.cuentas.domain.entities.movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructure.data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }




    }
}
