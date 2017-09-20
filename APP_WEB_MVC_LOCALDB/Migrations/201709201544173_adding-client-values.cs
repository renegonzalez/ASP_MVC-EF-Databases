namespace APP_WEB_MVC_LOCALDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingclientvalues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CONTACTOS_CLIENTE",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        telefono = c.Long(),
                        fax = c.Long(),
                        movil = c.Long(),
                        cliente_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CLIENTES", t => t.cliente_id)
                .Index(t => t.cliente_id);
            
            CreateTable(
                "dbo.CUENTAS_CLIENTE",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        banco = c.Int(nullable: false),
                        sucursal = c.Int(nullable: false),
                        num_cuenta = c.Long(nullable: false),
                        cliente_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CLIENTES", t => t.cliente_id)
                .Index(t => t.cliente_id);
            
            CreateTable(
                "dbo.DIRECCIONES_CLIENTE",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        direccion = c.String(),
                        cp = c.Int(),
                        provincia = c.String(),
                        cliente_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CLIENTES", t => t.cliente_id)
                .Index(t => t.cliente_id);
            
            AddColumn("dbo.CLIENTES", "nif", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DIRECCIONES_CLIENTE", "cliente_id", "dbo.CLIENTES");
            DropForeignKey("dbo.CUENTAS_CLIENTE", "cliente_id", "dbo.CLIENTES");
            DropForeignKey("dbo.CONTACTOS_CLIENTE", "cliente_id", "dbo.CLIENTES");
            DropIndex("dbo.DIRECCIONES_CLIENTE", new[] { "cliente_id" });
            DropIndex("dbo.CUENTAS_CLIENTE", new[] { "cliente_id" });
            DropIndex("dbo.CONTACTOS_CLIENTE", new[] { "cliente_id" });
            DropColumn("dbo.CLIENTES", "nif");
            DropTable("dbo.DIRECCIONES_CLIENTE");
            DropTable("dbo.CUENTAS_CLIENTE");
            DropTable("dbo.CONTACTOS_CLIENTE");
        }
    }
}
