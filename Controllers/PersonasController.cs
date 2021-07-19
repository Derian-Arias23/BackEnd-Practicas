using ApiPracticas.Context;
using ApiPracticas.Interface;
using ApiPracticas.Models;
using ApiPracticas.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;

namespace ApiPracticas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaInterface _personaInterface;

        public PersonasController(PersonaInterface personaInterface)
        {
            this._personaInterface = personaInterface;
        }

        [HttpGet]
        [Route("Get/{id_p}")]
        public ActionResult Get(int id_p)
        {
            try
            {
                var persona = _personaInterface.Get(id_p);
                
                return Ok(persona.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // POST api/values
        [HttpPost]
        [Route("Post")]
        public ActionResult Post(Personas persona)
        {
            if (ModelState.IsValid) 
            {    
            var res = _personaInterface.Post(persona); 
            return Ok("Registro guardado de forma correcta.");

            }
                else
                {
                    return BadRequest();
                }

        }

        // PUT api/values/5
        [HttpPut]
        [Route("Put/{id_p}")]
        public ActionResult Put(int id_p, [FromBody] Personas persona)
        {
            if(ModelState.IsValid)
            {
                if (persona.id_persona == id_p)
                {
                    var res = _personaInterface.Put(id_p, persona);
                    return Ok("Registro actualizado");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("Delete/{id_p}")]
        public ActionResult Delete(int id_p)
        {
            try
            {
                var res = _personaInterface.Delete(id_p);
                return Ok("Registro eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
