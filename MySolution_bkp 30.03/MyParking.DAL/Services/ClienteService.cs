using MyParking.DAL.Context;
using MyParking.DAL.Models;
using MyParking.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyParking.DAL.Services
{
    public class ClienteService
    {
        private MyParkingContext db = new MyParkingContext();
        public Result GravaCliente(Cliente cliente)
        {
            Result result = new Result();
            try
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                result.AdicionaMensagem("Gravação do Cliente Concluída", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                result.AdicionaMensagem(ex.Message, Result.TipoResult.Error);
            }

            return result;
        }

        public Cliente ListaCliente()
        {
            try
            {
                db.Clientes.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }
    }
}
