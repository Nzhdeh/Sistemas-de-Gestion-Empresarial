using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_SaludoMVC.Models
{
    public class ClsPersona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}