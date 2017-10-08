namespace APP_WEB_MVC_LOCALDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingvehicles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CONTACTOS_CLIENTE", "cliente_id", "dbo.CLIENTES");
            DropForeignKey("dbo.CUENTAS_CLIENTE", "cliente_id", "dbo.CLIENTES");
            DropForeignKey("dbo.DIRECCIONES_CLIENTE", "cliente_id", "dbo.CLIENTES");
            DropIndex("dbo.CONTACTOS_CLIENTE", new[] { "cliente_id" });
            DropIndex("dbo.CUENTAS_CLIENTE", new[] { "cliente_id" });
            DropIndex("dbo.DIRECCIONES_CLIENTE", new[] { "cliente_id" });
            RenameColumn(table: "dbo.CONTACTOS_CLIENTE", name: "cliente_id", newName: "clienteID");
            RenameColumn(table: "dbo.CUENTAS_CLIENTE", name: "cliente_id", newName: "clienteID");
            RenameColumn(table: "dbo.DIRECCIONES_CLIENTE", name: "cliente_id", newName: "clienteID");
            CreateTable(
                "dbo.VEHICULOS",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        matricula = c.String(),
                        marca = c.String(),
                        modelo = c.String(),
                        numBastidor = c.String(),
                        tipoVehiculoID = c.Long(nullable: false),
                        clienteID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CLIENTES", t => t.clienteID, cascadeDelete: true)
                .ForeignKey("dbo.TIPOS_VEHICULO", t => t.tipoVehiculoID, cascadeDelete: true)
                .Index(t => t.tipoVehiculoID)
                .Index(t => t.clienteID);
            
            CreateTable(
                "dbo.TIPOS_VEHICULO",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.CONTACTOS_CLIENTE", "prioritario", c => c.Boolean(nullable: false));
            AddColumn("dbo.CUENTAS_CLIENTE", "prioritario", c => c.Boolean(nullable: false));
            AddColumn("dbo.DIRECCIONES_CLIENTE", "prioritario", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CONTACTOS_CLIENTE", "clienteID", c => c.Long(nullable: false));
            AlterColumn("dbo.CUENTAS_CLIENTE", "clienteID", c => c.Long(nullable: false));
            AlterColumn("dbo.DIRECCIONES_CLIENTE", "clienteID", c => c.Long(nullable: false));
            CreateIndex("dbo.CONTACTOS_CLIENTE", "clienteID");
            CreateIndex("dbo.CUENTAS_CLIENTE", "clienteID");
            CreateIndex("dbo.DIRECCIONES_CLIENTE", "clienteID");
            AddForeignKey("dbo.CONTACTOS_CLIENTE", "clienteID", "dbo.CLIENTES", "id", cascadeDelete: true);
            AddForeignKey("dbo.CUENTAS_CLIENTE", "clienteID", "dbo.CLIENTES", "id", cascadeDelete: true);
            AddForeignKey("dbo.DIRECCIONES_CLIENTE", "clienteID", "dbo.CLIENTES", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DIRECCIONES_CLIENTE", "clienteID", "dbo.CLIENTES");
            DropForeignKey("dbo.CUENTAS_CLIENTE", "clienteID", "dbo.CLIENTES");
            DropForeignKey("dbo.CONTACTOS_CLIENTE", "clienteID", "dbo.CLIENTES");
            DropForeignKey("dbo.VEHICULOS", "tipoVehiculoID", "dbo.TIPOS_VEHICULO");
            DropForeignKey("dbo.VEHICULOS", "clienteID", "dbo.CLIENTES");
            DropIndex("dbo.VEHICULOS", new[] { "clienteID" });
            DropIndex("dbo.VEHICULOS", new[] { "tipoVehiculoID" });
            DropIndex("dbo.DIRECCIONES_CLIENTE", new[] { "clienteID" });
            DropIndex("dbo.CUENTAS_CLIENTE", new[] { "clienteID" });
            DropIndex("dbo.CONTACTOS_CLIENTE", new[] { "clienteID" });
            AlterColumn("dbo.DIRECCIONES_CLIENTE", "clienteID", c => c.Long());
            AlterColumn("dbo.CUENTAS_CLIENTE", "clienteID", c => c.Long());
            AlterColumn("dbo.CONTACTOS_CLIENTE", "clienteID", c => c.Long());
            DropColumn("dbo.DIRECCIONES_CLIENTE", "prioritario");
            DropColumn("dbo.CUENTAS_CLIENTE", "prioritario");
            DropColumn("dbo.CONTACTOS_CLIENTE", "prioritario");
            DropTable("dbo.TIPOS_VEHICULO");
            DropTable("dbo.VEHICULOS");
            RenameColumn(table: "dbo.DIRECCIONES_CLIENTE", name: "clienteID", newName: "cliente_id");
            RenameColumn(table: "dbo.CUENTAS_CLIENTE", name: "clienteID", newName: "cliente_id");
            RenameColumn(table: "dbo.CONTACTOS_CLIENTE", name: "clienteID", newName: "cliente_id");
            CreateIndex("dbo.DIRECCIONES_CLIENTE", "cliente_id");
            CreateIndex("dbo.CUENTAS_CLIENTE", "cliente_id");
            CreateIndex("dbo.CONTACTOS_CLIENTE", "cliente_id");
            AddForeignKey("dbo.DIRECCIONES_CLIENTE", "cliente_id", "dbo.CLIENTES", "id");
            AddForeignKey("dbo.CUENTAS_CLIENTE", "cliente_id", "dbo.CLIENTES", "id");
            AddForeignKey("dbo.CONTACTOS_CLIENTE", "cliente_id", "dbo.CLIENTES", "id");
        }
    }
}
