namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracao", "valorHora", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configuracao", "valorHora");
        }
    }
}
