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
    public class RolService : RolInterface
    {
        private readonly AppDBContext dBRContext;
        public RolService(AppDBContext dbr)
        {
            dBRContext = dbr;
        }
        public ActionResult<List<rol>> GetR(int id_r)
        {
            try
            {
                dynamic Rol = null;
                if (id_r == 0)
                {
                    Rol = dBRContext.rol.ToList();
                }
                else
                {
                    Rol = dBRContext.rol.Where(r => r.id_rol == id_r).ToList();
                }

                return Rol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult<rol> Post([FromBody] rol Rol)
        {
            try
            {
                dBRContext.rol.Add(Rol);
                dBRContext.SaveChanges();

                return Rol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult<rol> Put(int id_r, [FromBody] rol Rol)
        {
            try
            {
                if (Rol.id_rol == id_r)
                {
                    dBRContext.Entry(Rol).State = EntityState.Modified;
                    dBRContext.SaveChanges();
                    return dBRContext.rol.FirstOrDefault(r => r.id_rol == id_r); ;
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
        public ActionResult<rol> Delete(int id_r)
        {
            try
            {
                var Rol = dBRContext.rol.FirstOrDefault(r => r.id_rol == id_r);
                if (Rol != null)
                {
                    dBRContext.rol.Remove(Rol);
                    dBRContext.SaveChanges();
                    return Rol;
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
