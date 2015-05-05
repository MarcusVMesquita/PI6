namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig0041 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ConfVagas", newName: "Configuracao");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Configuracao", newName: "ConfVagas");
        }
    }
}
