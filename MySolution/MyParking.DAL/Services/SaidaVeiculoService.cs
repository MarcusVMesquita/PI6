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
    public class SaidaVeiculoService
    {
        private MyParkingContext db = new MyParkingContext();

        public IEnumerable<SaidaVeiculo> SaidasToList()
        {
            return db.saidas.ToList();
        }

        public decimal CalculaEstadia(DateTime Entrada, DateTime Saida)
        {   
            Configuracao configEstacionamento = new Configuracao();
            configEstacionamento = db.configuracao.First();

            decimal ValorEntrada = configEstacionamento.valorPrimeiraHora;
            decimal ValorHoraAdic = configEstacionamento.valorHoraAdicional;

            //datediff 

            TimeSpan EstadiaEmDias = Convert.ToDateTime(Saida).Subtract(Convert.ToDateTime(Entrada));

            int EstadiaEmHoras = EstadiaEmDias.Hours;

            return ValorEntrada + ((EstadiaEmHoras - 1) * ValorHoraAdic);
        }

        public Result EfetuarSaida(SaidaVeiculo novaSaida)
        { 
            var m = db.entradas.Where(model => model.PlacaVeiculo.ToUpper() == novaSaida.PlacaVeiculo.ToUpper());

            if (m == null)
                return new Result("Nenhum veículo com esta placa está no estacionamento", Result.TipoResult.Error);

            EntradaVeiculo entradaSair = new EntradaVeiculo();
           

            entradaSair = m.First();

            novaSaida.HorarioEntrada = entradaSair.HorarioEntrada;
            novaSaida.PlacaVeiculo = entradaSair.PlacaVeiculo;
            novaSaida.HorarioSaida = DateTime.Now;

            decimal valorEstadia = CalculaEstadia(novaSaida.HorarioEntrada, novaSaida.HorarioSaida);

            novaSaida.ValorEstadia = valorEstadia;

            try
            {
                db.saidas.Add(novaSaida);
                db.entradas.Remove(entradaSair);
                
                db.SaveChanges();

                return new Result("Saída efetuada com sucesso", Result.TipoResult.OK);
            }
            catch (Exception expt)
            {
                return new Result("Erro na gravação da saída" + "\n" + "Erro: " + expt.Message, Result.TipoResult.Error);
            }   

        }
    }
}
