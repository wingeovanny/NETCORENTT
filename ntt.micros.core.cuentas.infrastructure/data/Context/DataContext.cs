
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("TestDb");
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
