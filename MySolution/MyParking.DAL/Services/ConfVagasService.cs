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
    public class ConfVagasService
    {
        MyParkingContext db = new MyParkingContext();

        public ConfVagas getTamanho()
        {
            try
            {
                return db.configVaga.First();
            }
            catch (Exception expt)
            {
                throw;
            }
        }
        
        public Result definirTamanho(ConfVagas novaConf)
        {
            try
            {
                var m = db.configVaga.First();
                
                if ( m != null)
                {
                    db.configVaga.Remove(m);
                    db.configVaga.Add(novaConf);

                    db.SaveChanges();

                    return new Result("Tamanho do estacionamento definido com sucesso", Result.TipoResult.OK);
          
                }
               
                db.configVaga.Add(novaConf);
                return new Result("Tamanho do estacionamento definido com sucesso", Result.TipoResult.OK);

            }
            catch (Exception expt)
            {
                return new Result("Não foi possivel definir o tamanho do estacionamento" + expt.Message, Result.TipoResult.Error);
            }


        }

    }
}
