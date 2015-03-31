using MyParking.DAL.Context;
using MyParking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MyParking.Framework;

namespace MyParking.DAL.Services
{
    public class CorService
    {
        MyParkingContext db = new MyParkingContext();
        public IEnumerable<CorVeiculo> CorToList()
        {
            try
            {
                return db.corVeiculo.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Result GravaCor(CorVeiculo cor)
        {
            try
            {
                if (cor.ID != 0) //Editando a cor
                    db.Entry(cor).State = EntityState.Modified;
                else
                    db.corVeiculo.Add(cor);

                db.SaveChanges();

                return new Result("Cor de Veículo Gravado com Sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação da Cor" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public CorVeiculo getCor(int id)
        {
            try
            {
                return db.corVeiculo.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Result DeleteCor(int id)
        {
            CorVeiculo cor = getCor(id);
            db.corVeiculo.Remove(cor);
            db.SaveChanges();

            return new Result("Cor deletada com sucesso", Result.TipoResult.OK);
        }
    }
}
