using APP_WEB_MVC_LOCALDB.Models;
using System.Data.Entity;

namespace APP_WEB_MVC_LOCALDB.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() :base("name=MySQLContext") {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            modelBuilder.Entity<Cliente>().ToTable("CLIENTES");
            modelBuilder.Entity<Cliente>().HasKey(c => c.id);
            modelBuilder.Entity<Cliente>().Property(c => c.nombre).HasMaxLength(250);
        }

        public DbSet<Cliente> clientes { get; set; }
    }
}