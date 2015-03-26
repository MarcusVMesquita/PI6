namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyParkingDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(nullable: false, maxLength: 15),
                        SobreNome = c.String(nullable: false, maxLength: 30),
                        CPF = c.String(nullable: false, maxLength: 14),
                        CEP = c.String(nullable: false),
                        Endereco = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
