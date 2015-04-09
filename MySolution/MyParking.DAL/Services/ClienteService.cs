using MyParking.DAL.Context;
using MyParking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MyParking.Framework;
using System.Data.Entity.Validation;


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

        public Cliente GetCliente(int id = 0)
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
                cliente.NomeCliente = Extensions.ProperCase(cliente.NomeCliente);
                cliente.SobreNome = Extensions.ProperCase(cliente.SobreNome);
                cliente.Endereco = Extensions.ProperCase(cliente.Endereco);

                cliente.CPF = Extensions.FormataString("###.###.###-##", cliente.CPF);
                cliente.CEP = Extensions.FormataString("#####-###", cliente.CEP);
                cliente.Veiculo.PlacaVeiculo = Extensions.FormataString("###-####", cliente.Veiculo.PlacaVeiculo).ToUpper();

                //Faz a Gravação
                if (cliente.id_cliente != 0) //Esta Editando um existente
                    db.Entry(cliente).State = EntityState.Modified;
                else
                {
                    if (GetClienteByCPF(cliente.CPF) != null)
                        return new Result("Já existe um cliente cadastrado com esse CPF.", Result.TipoResult.Alert);

                    db.clientes.Add(cliente);
                }

                db.SaveChanges();

                return new Result("Cliente Gravado com Sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação do Cliente" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        private Cliente GetClienteByCPF(string CPFCliente)
        {
            try
            {
                var m = db.clientes.Where(model => model.CPF.ToUpper() == CPFCliente.ToUpper());

                if (m.Count() > 0)
                {
                    Cliente cliente = m.First();
                    return cliente;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Result DeleteCliente(int id)
        {
            Cliente cliente = GetCliente(id);
            db.clientes.Remove(cliente);
            db.SaveChanges();

            return new Result("Cliente deletado com sucesso", Result.TipoResult.OK);
        }
    }
}
