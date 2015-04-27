namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyParking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        id_Vaga = c.Int(nullable: false, identity: true),
                        Ocupado = c.Byte(nullable: false),
                        PlacaVeiculo = c.String(),
                    })
                .PrimaryKey(t => t.id_Vaga);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vaga");
        }
    }
}
