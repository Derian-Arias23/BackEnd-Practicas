using ApiPracticas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Interface
{
    public interface RolInterface
    {
        ActionResult<List<rol>> GetR(int id_r);
        ActionResult<rol> Post([FromBody] rol Rol);
        ActionResult<rol> Put(int id_r, [FromBody] rol Rol);
        ActionResult<rol> Delete(int id_r);
    }
}
