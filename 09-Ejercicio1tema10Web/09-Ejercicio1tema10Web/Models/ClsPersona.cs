using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_Ejercicio1tema10Web.Models
{
    public class ClsPersona
    {
        public ClsPersona()
        {
            this.IdPersona = 0;
            this.NombrePersona = "No nombre";
            this.ApellidosPersona = "No apellidos";
            this.FechaNacimientoPersona = "2000/10/10";
            this.TelefonoPersona = "6656555444";
            this.FotoPersona = new List<byte>();
        }

        public int IdPersona { get; set; }
        public String NombrePersona { get; set; }
        public String ApellidosPersona { get; set; }
        public DateTime FechaNacimientoPersona { get; set; }
        public String TelefonoPersona { get; set; }
        public List<Byte> FotoPersona { get; set; }
    }
}