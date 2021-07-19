using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Models
{
    public class rol
    {
        [Key]
        public int id_rol { get; set; }

        public string descripcion { get; set; }

    }
}
