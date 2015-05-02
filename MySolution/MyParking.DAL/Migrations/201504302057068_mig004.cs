namespace MyParking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig004 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Configuracao", newName: "ConfVagas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ConfVagas", newName: "Configuracao");
        }
    }
}
