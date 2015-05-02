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
        public DbSet<MarcaVeiculo> marcaVeiculo { get; set; }
        public DbSet<CorVeiculo> corVeiculo { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<EntradaVeiculo> entradas { get; set; }
        public DbSet<ConfVagas> configVaga { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
