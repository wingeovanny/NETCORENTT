using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ntt.micros.core.cuentas.domainDB.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntt.micros.core.cuentas.infrastructureDB.data.Context
{
    public partial class DataContextDB:  DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContextDB()
        {
        }

        public DataContextDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("NTTDB");
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuenta { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;


    }
}
