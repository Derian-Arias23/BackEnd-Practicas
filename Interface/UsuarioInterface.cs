using ApiPracticas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Interface
{
    public interface UsuarioInterface
    {
        ActionResult<List<Usuario>> GetU(string usua_nombre, string contraseña);
        ActionResult<Usuario> Post([FromBody] Usuario usuario);
        ActionResult<Usuario> Put(int id, [FromBody] Usuario usuario);
        ActionResult<Usuario> Delete(int id);
    }
}
