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

namespace ApiPracticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolInterface _rolInterface;
        public RolController(RolInterface rolInterface)
        {
            this._rolInterface = rolInterface;
        }

        // GET api/values
        [HttpGet]
        [Route("GetR")]
        public ActionResult GetR(int id_r)
        {
            try
            {
                dynamic Rol = _rolInterface.GetR(id_r);
                return Ok(Rol.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        [Route("Post")]
        public ActionResult Post([FromBody] rol Rol)
        {
            try
            {
                var resr = _rolInterface.Post(Rol);
                return Ok("Registro guardado de forma correcta.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/values/5
        [HttpPut]
        [Route("Get/(id_r)")]
        public ActionResult Put(int id_r, [FromBody] rol Rol)
        {
            try
            {
                if (Rol.id_rol == id_r)
                {
                    var resr = _rolInterface.Put(id_r, Rol);
                    return Ok("Registro actualizado");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("Get/(id_r)")]
        public ActionResult Delete(int id_r)
        {
            try
            {
                var resr = _rolInterface.Delete(id_r);
                return Ok("Registro eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
