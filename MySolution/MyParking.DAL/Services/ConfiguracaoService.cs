using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyParking.DAL.Models;
using System.Threading.Tasks;
using MyParking.Framework;
using MyParking.DAL.Context;

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
        
        public Result definirTamanho(Configuracao novaConf)
        {
            try
            {
                var m = db.configuracao.First();
                
                if ( m != null)
                {
                    db.configuracao.Remove(m);
                    db.configuracao.Add(novaConf);

                    db.SaveChanges();

                    return new Result("Tamanho do estacionamento definido com sucesso", Result.TipoResult.OK);
          
                }
               
                db.configuracao.Add(novaConf);
                return new Result("Tamanho do estacionamento definido com sucesso", Result.TipoResult.OK);

            }
            catch (Exception expt)
            {
                return new Result("Não foi possivel definir o tamanho do estacionamento" + expt.Message, Result.TipoResult.Error);
            }


        }

    }
}
