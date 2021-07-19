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
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioInterface _usuarioInterface;

        public UsuarioController(UsuarioInterface usuarioInterface)
        {
            this._usuarioInterface = usuarioInterface;
        }

        // GET api/values
        [HttpGet]
        [Route("GetU/{usua_nombre}/{contraseña}")]
        public ActionResult GetU(string usua_nombre, string contraseña)
        {
            try
            {
                var usuario = _usuarioInterface.GetU(usua_nombre, contraseña);
                return Ok(usuario.Value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/values
        [HttpPost]
        [Route("Post")]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var resu = _usuarioInterface.Post(usuario);
                return Ok("Registro guardado de forma correcta.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/values/5
        [HttpPut]
        [Route("Put/{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.id_usua == id)
                {
                    var res = _usuarioInterface.Put(id, usuario);
                    return Ok("Registro actualizado");
                }
                else
                {
                    return BadRequest();
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var resu = _usuarioInterface.Delete(id);
                return Ok("Registro eliminado");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
