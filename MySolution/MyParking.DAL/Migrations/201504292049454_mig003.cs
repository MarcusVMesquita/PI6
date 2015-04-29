namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntradaVeiculo",
                c => new
                    {
                        id_Entrada = c.Int(nullable: false, identity: true),
                        PlacaVeiculo = c.String(nullable: false),
                        HorarioEntrada = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_Entrada);
            
            DropTable("dbo.Vaga");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        id_Vaga = c.Int(nullable: false, identity: true),
                        Ocupado = c.Boolean(nullable: false),
                        PlacaVeiculo = c.String(),
                        HorarioEntrada = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_Vaga);
            
            DropTable("dbo.EntradaVeiculo");
        }
    }
}
