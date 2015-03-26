using MyParking.DAL.Context;
using MyParking.DAL.Models;

namespace MyParking.DAL.Services
{
    public class ClienteService
    {
        private MyParkingContext db = new MyParkingContext();
        public bool GravaCliente(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();

            return true;
        }
    }
}
