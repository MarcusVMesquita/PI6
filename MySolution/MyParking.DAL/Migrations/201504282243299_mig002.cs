namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configuracao",
                c => new
                    {
                        id_configuracao = c.Int(nullable: false, identity: true),
                        qtdeVagas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_configuracao);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configuracao");
        }
    }
}
