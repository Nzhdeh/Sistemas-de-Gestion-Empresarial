using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_SaludoMVC.Models
{
    public class ClsPersona
    {
        public ClsPersona(int idPersona,String nombre,String apellidos,DateTime fechaNac)
        {
            this.IdPersona = idPersona;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNac = fechaNac;
        }
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
    }
}