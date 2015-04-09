namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyParking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        id_cliente = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(nullable: false, maxLength: 15),
                        SobreNome = c.String(nullable: false, maxLength: 30),
                        CPF = c.String(nullable: false, maxLength: 14),
                        CEP = c.String(nullable: false),
                        Endereco = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        id_veiculo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_cliente)
                .ForeignKey("dbo.Veiculo", t => t.id_veiculo, cascadeDelete: true)
                .Index(t => t.id_veiculo);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        id_veiculo = c.Int(nullable: false, identity: true),
                        PlacaVeiculo = c.String(nullable: false, maxLength: 8),
                        ModeloVeiculo = c.String(),
                        id_marca = c.Int(nullable: false),
                        id_cor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_veiculo)
                .ForeignKey("dbo.MarcaVeiculo", t => t.id_marca, cascadeDelete: true)
                .ForeignKey("dbo.CorVeiculo", t => t.id_cor, cascadeDelete: true)
                .Index(t => t.id_marca)
                .Index(t => t.id_cor);
            
            CreateTable(
                "dbo.MarcaVeiculo",
                c => new
                    {
                        id_marca = c.Int(nullable: false, identity: true),
                        NomeMarca = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.id_marca);
            
            CreateTable(
                "dbo.CorVeiculo",
                c => new
                    {
                        id_cor = c.Int(nullable: false, identity: true),
                        NomeCor = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.id_cor);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id_usuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Login = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 15),
                        ConfirmPassword = c.String(),
                        Administrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_usuario);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Veiculo", new[] { "id_cor" });
            DropIndex("dbo.Veiculo", new[] { "id_marca" });
            DropIndex("dbo.Cliente", new[] { "id_veiculo" });
            DropForeignKey("dbo.Veiculo", "id_cor", "dbo.CorVeiculo");
            DropForeignKey("dbo.Veiculo", "id_marca", "dbo.MarcaVeiculo");
            DropForeignKey("dbo.Cliente", "id_veiculo", "dbo.Veiculo");
            DropTable("dbo.Usuario");
            DropTable("dbo.CorVeiculo");
            DropTable("dbo.MarcaVeiculo");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Cliente");
        }
    }
}
