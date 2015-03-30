using MyParking.DAL.Context;
using MyParking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;


namespace MyParking.DAL.Services
{
    public class ClienteService
    {
        private MyParkingContext db = new MyParkingContext();

        public IEnumerable<Cliente> ClienteToList()
        {
            try
            {
                return db.clientes.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Cliente getCliente(int id = 0)
        {
            try
            {
                return db.clientes.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GravaCliente(Cliente cliente)
        {
            try
            {
                if (cliente.ID != 0) //Esta Editando um existente
                    db.Entry(cliente).State = EntityState.Modified;
                else
                    db.clientes.Add(cliente);

                db.SaveChanges();                    
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteCliente(int id)
        {
            Cliente cliente = getCliente(id);
            db.clientes.Remove(cliente);
            db.SaveChanges();
        }
    }
}
