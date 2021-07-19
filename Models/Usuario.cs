using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Models
{
    public class Usuario
    {
        [Key]
        public int id_usua { get; set; }
        public string usua_nombre { get; set; }
        public string contraseña { get; set; }
        public int id_rol { get; set; }


    }
}
