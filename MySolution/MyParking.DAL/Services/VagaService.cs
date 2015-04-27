using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyParking.DAL.Context;
using MyParking.DAL.Models;
using MyParking.Framework;

namespace MyParking.DAL.Services
{
    public class VagaService
    {
        private MyParkingContext db = new MyParkingContext();

        public IEnumerable<Vaga> VagaToList()
        {
            try
            {
                return db.vagas.ToList();
            }
            catch (Exception expt)
            {
                throw;
            }
        }

        //Determina quantas vagas possui o estacionamento
        public Result SetNumVagas(int qtdeVagas)
        {
            for (int i = 1; i == qtdeVagas; i++)
            {
                try
                {
                    Vaga novaVaga = new Vaga();
                    novaVaga.Ocupado = 0;

                    db.vagas.Add(novaVaga);

                    return new Result("Vagas registradas com sucesso", Result.TipoResult.OK);
                }
                catch (Exception expt)
                {
                    throw;
                }
            }
            return new Result("Não foi possivel registrar as vagas do estacionamento", Result.TipoResult.Error);
        }
    }
}
