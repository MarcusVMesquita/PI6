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

        public CorVeiculo GetCorByName(string NomeCor)
        {
            try
            {
                var m = db.corVeiculo.Where(model => model.NomeCor.ToUpper() == NomeCor.ToUpper());

                if (m.Count() > 0)
                {
                    CorVeiculo cor = m.First();
                    return cor;
                }

                return null;
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
                //Deixa as primeiras letras Maisculas
                cor.NomeCor = Extensions.ProperCase(cor.NomeCor);

                if (cor.id_cor != 0) //Editando a cor
                    db.Entry(cor).State = EntityState.Modified;
                else
                {
                    if (GetCorByName(cor.NomeCor) != null)
                        return new Result("Já existe uma cor cadastrada com esse nome.", Result.TipoResult.Alert);

                    db.corVeiculo.Add(cor);
                }

                db.SaveChanges();

                return new Result("Cor de Veículo Gravado com Sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação da Cor" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public CorVeiculo GetCor(int id)
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
            try
            {
                CorVeiculo cor = GetCor(id);
                db.corVeiculo.Remove(cor);
                db.SaveChanges();

                return new Result("Cor deletada com sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na exclusão da Cor" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }
    }
}
