using ApiPracticas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Interface
{
    public interface PersonaInterface
    {
        ActionResult<List<Personas>> Get(int id_p);
        ActionResult<Personas> Post(Personas persona);
        ActionResult<Personas> Put(int id_p, [FromBody] Personas persona);
        ActionResult<Personas> Delete(int id_p);

    }
}
