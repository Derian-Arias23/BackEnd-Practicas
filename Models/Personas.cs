using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Models
{
    
    public class Personas
    {
        [Key]
        public int id_persona { get; set; }

        //[Required(ErrorMessage = "Campo obligatorio. Ingrese el nombre completo")]
        public string Nombres { get; set; }

        //[Required(ErrorMessage = "Campo obligatorio, ingrese el número de cédula")]
        //[StringLength(10, ErrorMessage = "Número incorrecto, solo se permiten 10 dígitos")]
        public int Cédula { get; set; }

        //[Required(ErrorMessage = "Campos obligatorio, ingrese la dirección")]
        //[DataType(DataType.Text)]
        public string Dirección { get; set; }

        //[Required(ErrorMessage = "Campos obligatorio, ingrese el número de teléfono")]
        //[DataType(DataType.PhoneNumber)]
        //[StringLength(10, ErrorMessage = "Número incorrecto, solo se permiten 10 dígitos")]
        public string Teléfono { get; set; }

        //[Required(ErrorMessage = "Campos obligatorio, ingrese el número de teléfono")]
        public DateTime fecha_registro { get; set; }
    }
}
