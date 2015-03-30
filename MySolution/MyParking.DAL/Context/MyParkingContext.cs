using MyParking.DAL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyParking.DAL.Context
{
    public class MyParkingContext : DbContext
    {
        public MyParkingContext()
            : base("MyParkingDatabase")
        { }

        public DbSet<Cliente> clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
