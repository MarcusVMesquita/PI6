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

        public Result definirTamanho(int tamEstacionamento)
        {
            ConfVagas novaConf = new ConfVagas();
            novaConf.qtdeVagas = tamEstacionamento;

            try
            {
                var m = db.configVaga.First();
                
                if ( m != null)
                {
                    db.configVaga.Remove(m);
                    db.configVaga.Add(novaConf);

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
