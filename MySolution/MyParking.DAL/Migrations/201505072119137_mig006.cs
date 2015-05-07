namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracao", "valorPrimeiraHora", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Configuracao", "valorHoraAdicional", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Configuracao", "valorMensalista", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Configuracao", "valorHora");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Configuracao", "valorHora", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Configuracao", "valorMensalista");
            DropColumn("dbo.Configuracao", "valorHoraAdicional");
            DropColumn("dbo.Configuracao", "valorPrimeiraHora");
        }
    }
}
