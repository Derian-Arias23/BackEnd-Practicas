using ApiPracticas.Context;
using ApiPracticas.Interface;
using ApiPracticas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Service
{
    public class UsuarioService : UsuarioInterface
    {
        private readonly AppDBContext dBContext;
        public UsuarioService(AppDBContext db)
        {
            dBContext = db;
        }
        public ActionResult<List<Usuario>> GetU(string usua_nombre, string contraseña)
        {
            try
            {
                var usuarios = dBContext.Usuario.Where(usuario =>
                                usuario.usua_nombre.Equals(usua_nombre)
                                && usuario.contraseña.Equals(contraseña)).ToList();

                if (usuarios != null)
                {
                   return usuarios;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            /*try
            {
                dynamic usuario = null;
                if (id_u == 0)
                {
                    usuario = dBContext.Usuario.ToList();
                }
                else
                {
                    usuario = dBContext.Usuario.Where(f => f.id_usua == id_u).ToList();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }*/
        }

        private ActionResult<List<Usuario>> NotFound()
        {
            throw new NotImplementedException();
        }

        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            try
            {
                dBContext.Usuario.Add(usuario);
                dBContext.SaveChanges();
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult<Usuario> Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.id_usua == id)
                {
                    dBContext.Entry(usuario).State = EntityState.Modified;
                    dBContext.SaveChanges();
                    return dBContext.Usuario.FirstOrDefault(u => u.id_usua == id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult<Usuario> Delete(int id)
        {
            try
            {
                var usuario = dBContext.Usuario.FirstOrDefault(f => f.id_usua == id);
                if (usuario != null)
                {
                    dBContext.Usuario.Remove(usuario);
                    dBContext.SaveChanges();
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
