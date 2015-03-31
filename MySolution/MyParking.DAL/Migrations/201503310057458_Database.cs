namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorVeiculo", "corVeiculo", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.CorVeiculo", "Cor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CorVeiculo", "Cor", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.CorVeiculo", "corVeiculo");
        }
    }
}
