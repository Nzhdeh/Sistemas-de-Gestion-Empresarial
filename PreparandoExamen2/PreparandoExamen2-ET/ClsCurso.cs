using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_ET
{
    public class ClsCurso
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }

        public ClsCurso()
        {
            this.IdCurso = 0;
            this.NombreCurso = "No hay";
        }

        public ClsCurso(int id,string nombre)
        {
            this.IdCurso = id;
            this.NombreCurso = nombre;
        }
    }
}