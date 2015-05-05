using System;
using System.Collections.Generic;
using MyParking.DAL.Models;
using MyParking.DAL.Context;
using System.Linq;
using MyParking.Framework;
using System.Data.Entity;

namespace MyParking.DAL.Services
{
    public class UsuarioService
    {
        MyParkingContext db = new MyParkingContext();

        public IEnumerable<Usuario> UsuarioToList()
        {
            try
            {
                return db.usuarios.ToList();
            }
            catch (Exception expt)
            {
                throw;
            }
        }

        public Usuario GetUsuario(int id)
        {
            try
            {
                return db.usuarios.Find(id);
            }
            catch (Exception expt)
            {
                throw;
            }

        }

        public Usuario getUsrByLogin(string Login)
        {
            try
            {
                var usr = db.usuarios.Where(model => model.Login.ToUpper() == Login.ToUpper());

                if (usr.Count() > 0)
                {
                    Usuario usuario = usr.First();
                    return usuario;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Result GravaUsuario(Usuario usuario)
        {
            try
            {
                usuario.Nome = Extensions.ProperCase(usuario.Nome);

                //Faz a criptografia da senha
                usuario.Password = Cripto.Criptografar(usuario.Password, usuario.Login);

                if (usuario.id_usuario != 0) //Esta alterando
                    db.Entry(usuario).State = EntityState.Modified;
                else
                {
                    if (getUsrByLogin(usuario.Login) != null)
                        return new Result("Já existe um usuário com esse Log in.", Result.TipoResult.Alert);

                    db.usuarios.Add(usuario);
                }

                db.SaveChanges();

                return new Result("Usuário Gravado com Sucesso", Result.TipoResult.OK);
            }
            catch (Exception ex)
            {
                return new Result("Erro na gravação do Cliente" + "\n" + "Erro: " + ex.Message, Result.TipoResult.Error);
            }
        }

        public Result DeletaUsuario(int id)
        {
            Usuario usuario = GetUsuario(id);
            if (usuario.Administrador)
                return new Result("Não pode deletar o usuário administrador", Result.TipoResult.Alert);
            
            db.usuarios.Remove(usuario);
            db.SaveChanges();

            return new Result("Usuário deletado com sucesso", Result.TipoResult.OK);

        }

        

    }

}