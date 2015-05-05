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
    public class EntradaVeiculoService
    {
        private MyParkingContext db = new MyParkingContext();

        public IEnumerable<EntradaVeiculo> EntradasToList()
        {
            try
            {
                return db.entradas.ToList();
            }
            catch (Exception expt)
            {
                throw;
            }
        }

        public Result NovaEntrada(EntradaVeiculo NovaEntrada)
        {
            try
            {
                var m = db.configuracao.First();

                if (db.entradas.Count() >= m.qtdeVagas)
                    return new Result("O estacionamento está lotado", Result.TipoResult.Alert);

                if(GetEntradaByPlaca(NovaEntrada.PlacaVeiculo) != null)
                    return new Result("Já existe um registro para essa placa", Result.TipoResult.Alert);

                NovaEntrada.PlacaVeiculo = Extensions.FormataString("###-####", NovaEntrada.PlacaVeiculo).ToUpper();
                NovaEntrada.HorarioEntrada = DateTime.Now;

                db.entradas.Add(NovaEntrada);

                db.SaveChanges();

                return new Result("Entrada registrada com sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação da Vaga" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public IEnumerable<EntradaVeiculo> entradasToList()
        {
            try
            {
                return db.entradas.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private EntradaVeiculo GetEntradaByPlaca(string Placa)
        {
            try
            {
                var m = db.entradas.Where(model => model.PlacaVeiculo.ToUpper() == Placa.ToUpper());

                if (m.Count() > 0)
                {
                    EntradaVeiculo entrada = m.First();
                    return entrada;
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
