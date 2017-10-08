using APP_WEB_MVC_LOCALDB.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace APP_WEB_MVC_LOCALDB.Context
{
    public class LocalDBContext : DbContext
    {
        public LocalDBContext() :base("name=LocalDBContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here

            //CLIENTES
            modelBuilder.Entity<Cliente>().ToTable("CLIENTES")
                .HasKey(c => c.id);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.nombre)
                .HasMaxLength(250);
            modelBuilder.Entity<Cliente>()
                .HasMany<DatosContacto>(c => c.contactos)
                .WithRequired(dc=>dc.cliente)
                .HasForeignKey<long>(c=>c.clienteID);
            modelBuilder.Entity<Cliente>()
                .HasMany<DatosDireccion>(c => c.direcciones)
                .WithRequired(dc => dc.cliente)
                .HasForeignKey<long>(c => c.clienteID);
            modelBuilder.Entity<Cliente>()
                .HasMany<DatosBancarios>(c => c.datosBancos)
                .WithRequired(dc => dc.cliente)
                .HasForeignKey<long>(c => c.clienteID);

            //CONTACTOS_CLIENTE
            modelBuilder.Entity<DatosContacto>().ToTable("CONTACTOS_CLIENTE")
                .HasKey(cc => cc.id);
            //DIRECCIONES_CLIENTE
            modelBuilder.Entity<DatosDireccion>().ToTable("DIRECCIONES_CLIENTE")
                .HasKey(cc => cc.id);
            //CUENTAS_CLIENTE
            modelBuilder.Entity<DatosBancarios>().ToTable("CUENTAS_CLIENTE")
                .HasKey(cc => cc.id);

            //VEHICULOS
            modelBuilder.Entity<Vehiculo>().ToTable("VEHICULOS")
                .HasKey(veh => veh.id)
                .HasRequired<Cliente>(v => v.cliente)
                .WithMany(c => c.vehiculos)
                .HasForeignKey<long>(v=>v.clienteID);

            //TIPO_VEHICULO
            modelBuilder.Entity<TipoVehiculo>().ToTable("TIPOS_VEHICULO")
                .HasKey(vt => vt.id)
                .HasMany<Vehiculo>(v=>v.vehiculos)
                .WithRequired(v=>v.tipo)
                .HasForeignKey<long>(v=>v.tipoVehiculoID);
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<DatosContacto> contactosCliente { get; set; }
        public DbSet<DatosDireccion> direccionesCliente { get; set; }
        public DbSet<DatosBancarios> datosBancariosCliente { get; set; }
        public DbSet<Vehiculo> vehiculos { get; set; }
        public DbSet<TipoVehiculo> tiposVehiculos { get; set; }

    }
}