using APP_WEB_MVC_LOCALDB.Models;
using System.Data.Entity;

namespace APP_WEB_MVC_LOCALDB.Context
{
    public class LocalDBContext : DbContext
    {
        public LocalDBContext() :base("name=LocalDBContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            modelBuilder.Entity<Cliente>().ToTable("CLIENTES");
            modelBuilder.Entity<Cliente>().HasKey(c => c.id);
            modelBuilder.Entity<Cliente>().Property(c => c.nombre).HasMaxLength(250);
            modelBuilder.Entity<Cliente>().HasOptional<Contacto>(c => c.contactos).WithOptionalPrincipal(c => c.cliente);
            modelBuilder.Entity<Cliente>().HasOptional<Direccion>(c => c.direcciones).WithOptionalPrincipal(c => c.cliente);
            modelBuilder.Entity<Cliente>().HasOptional<DatosBancarios>(c => c.datosBancos).WithOptionalPrincipal(c => c.cliente);

            modelBuilder.Entity<Contacto>().ToTable("CONTACTOS_CLIENTE").HasKey(cc => cc.id);
            modelBuilder.Entity<Direccion>().ToTable("DIRECCIONES_CLIENTE").HasKey(cc => cc.id);
            modelBuilder.Entity<DatosBancarios>().ToTable("CUENTAS_CLIENTE").HasKey(cc => cc.id);
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Contacto> contactosCliente { get; set; }
        public DbSet<Direccion> direccionesCliente { get; set; }
        public DbSet<DatosBancarios> datosBancariosCliente { get; set; }

    }
}