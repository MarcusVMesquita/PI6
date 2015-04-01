using System;
using System.Collections.Generic;
using MyParking.DAL.Models;
using MyParking.DAL.Context;
using System.Linq;

namespace MyParking.DAL.Services
{
    public class UsuarioService
    {
        MyParkingContext db = new MyParkingContext();

        public IEnumerable<Usuario> UsuarioToList()
        {
            try
            {
               return db.usuarios.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
