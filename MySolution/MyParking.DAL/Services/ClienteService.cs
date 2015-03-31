using MyParking.DAL.Context;
using MyParking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MyParking.Framework;


namespace MyParking.DAL.Services
{
    public class ClienteService
    {
        private MyParkingContext db = new MyParkingContext();

        public IEnumerable<Cliente> ClienteToList()
        {
            try
            {
                return db.clientes.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Cliente getCliente(int id = 0)
        {
            try
            {
                return db.clientes.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Result GravaCliente(Cliente cliente)
        {    
            try
            {
                // regra de negócio
                if (!Extensions.CPFValido(cliente.CPF))
                    return new Result("CPF do Cliente não é válido.", Result.TipoResult.Alert);

                //Faz as formatações dos valores para salvar no banco de dados.
                //cliente.CPF = Extensions.FormataString("###.###.###-##", cliente.CPF);
                //cliente.CEP = Extensions.FormataString("#####-###", cliente.CEP);
                //cliente.veiculo.PlacaVeiculo = Extensions.FormataString("###-####", cliente.veiculo.PlacaVeiculo);

                //Faz a Gravação
                if (cliente.ID != 0) //Esta Editando um existente
                    db.Entry(cliente).State = EntityState.Modified;
                else
                    db.clientes.Add(cliente);

                db.SaveChanges();

                return new Result("Cliente Gravado com Sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação do Cliente" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public Result DeleteCliente(int id)
        {
            Cliente cliente = getCliente(id);
            db.clientes.Remove(cliente);
            db.SaveChanges();

            return new Result("Cliente deletado com sucesso", Result.TipoResult.OK);
        }
    }
}
