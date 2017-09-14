namespace APP_WEB_MVC_LOCALDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CLIENTES",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        nombre = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CLIENTES");
        }
    }
}
