namespace APP_WEB_MVC_LOCALDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CLIENTES", "apellidos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CLIENTES", "apellidos");
        }
    }
}
