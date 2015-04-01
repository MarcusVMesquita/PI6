namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Login = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 15),
                        Administrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Usuario2");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuario2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Login = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 15),
                        Administrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Usuario");
        }
    }
}
