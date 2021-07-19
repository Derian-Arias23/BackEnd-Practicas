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
    public class PersonaService : PersonaInterface
    {
        private readonly AppDBContext dBContext;
        public PersonaService(AppDBContext db)
        {
            dBContext = db;
        }
        public ActionResult<List<Personas>> Get(int id_p)
        {
            try
            {
                dynamic persona = null;
                if (id_p == 0)
                {
                    persona = dBContext.Personas.ToList();
                }
                else
                {
                    persona = dBContext.Personas.Where(p => p.id_persona == id_p).ToList();
                }

                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult<Personas> Post(Personas persona)
        {
                try
            {
                dBContext.Personas.Add(persona);
                dBContext.SaveChanges();

                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult<Personas> Put(int id_p, [FromBody] Personas persona)
        {
            try
            {
                if (persona.id_persona == id_p)
                {
                    dBContext.Entry(persona).State = EntityState.Modified;
                    dBContext.SaveChanges();
                    return dBContext.Personas.FirstOrDefault(p =>p.id_persona == id_p);
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
        public ActionResult<Personas> Delete(int id_p)
        {
            try
            {
                var persona = dBContext.Personas.FirstOrDefault(p => p.id_persona == id_p);
                if (persona != null)
                {
                    dBContext.Personas.Remove(persona);
                    dBContext.SaveChanges();
                    return persona;
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
