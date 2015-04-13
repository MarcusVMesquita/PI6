using MyParking.DAL.Context;
using MyParking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
                marca.NomeMarca = Extensions.ProperCase(marca.NomeMarca);

                if (marca.id_marca != 0) //Editando a marca
                    db.Entry(marca).State = EntityState.Modified;
                else
                {
                    if (GetMarcaByName(marca.NomeMarca) != null)
                        return new Result("Já existe uma marca cadastrada com esse nome.", Result.TipoResult.Alert);

                    db.marcaVeiculo.Add(marca);
                }
                db.SaveChanges();

                return new Result("Marca de Veículo Gravado com Sucesso.", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação da Marca" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public MarcaVeiculo GetMarca(int id)
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
            try
            {
                MarcaVeiculo marca = GetMarca(id);
                db.marcaVeiculo.Remove(marca);
                db.SaveChanges();

                return new Result("Marca deletada com sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro ao deletar a Marca." + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public MarcaVeiculo GetMarcaByName(string Marca)
        {
            try
            {
                var m = db.marcaVeiculo.Where(model => model.NomeMarca.ToUpper() == Marca.ToUpper());

                if (m.Count() > 0)
                {
                    MarcaVeiculo marca = m.First();
                    return marca;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
