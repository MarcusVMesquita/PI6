using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyParking.DAL.Models;
using System.Threading.Tasks;
using MyParking.Framework;
using MyParking.DAL.Context;
using System.Data.Entity;

namespace MyParking.DAL.Services
{
    public class ConfiguracaoService
    {
        MyParkingContext db = new MyParkingContext();

        public Configuracao getTamanho()
        {
            try
            {
                return db.configuracao.First();
            }
            catch (Exception expt)
            {
                throw;
            }
        }

        public Configuracao getConfById(int id = 0)
        {
            try
            {
                return db.configuracao.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public Result definirTamanho(Configuracao novaConf)
        {
            try
            {
                //Faz a Gravação
                if (novaConf.id_configuracao != 0) //Esta Editando um existente
                    db.Entry(novaConf).State = EntityState.Modified;
                else
                {
                    db.configuracao.Add(novaConf);
                }

                db.SaveChanges();

                return new Result("Tamanho do estacionamento definido com sucesso", Result.TipoResult.OK);

                //var m = db.configuracao.First();
                
                //if ( m != null)
                //{
                //    db.configuracao.Remove(m);
                //    db.configuracao.Add(novaConf);

                //    db.SaveChanges();

                    
          
                //}
               
                //db.configuracao.Add(novaConf);
                //return new Result("Tamanho do estacionamento definido com sucesso", Result.TipoResult.OK);

            }
            catch (Exception expt)
            {
                return new Result("Não foi possivel definir o tamanho do estacionamento" + expt.Message, Result.TipoResult.Error);
            }


        }

    }
}
