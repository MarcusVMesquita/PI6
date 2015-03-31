using MyParking.DAL.Context;
using MyParking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MyParking.Framework;

namespace MyParking.DAL.Services
{
    public class MarcaService
    {
        MyParkingContext db = new MyParkingContext();
        public IEnumerable<MarcaVeiculo> MarcaToList()
        {
            try
            {
                return db.marcaVeiculo.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Result GravaMarca(MarcaVeiculo marca)
        {
            try
            {
                if (marca.ID != 0) //Editando a marca
                    db.Entry(marca).State = EntityState.Modified;
                else
                    db.marcaVeiculo.Add(marca);

                db.SaveChanges();

                return new Result("Marca de Veículo Gravado com Sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação da Marca" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public MarcaVeiculo getMarca(int id)
        {
            try
            {
                return db.marcaVeiculo.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Result DeleteMarca(int id)
        {
            MarcaVeiculo marca = getMarca(id);
            db.marcaVeiculo.Remove(marca);
            db.SaveChanges();

            return new Result("Marca deletada com sucesso", Result.TipoResult.OK);
        }
    }
}
