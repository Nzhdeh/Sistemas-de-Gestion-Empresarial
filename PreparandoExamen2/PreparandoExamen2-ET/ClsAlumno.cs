using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_ET
{
    public class ClsAlumno
    {
        public ClsAlumno()
        {
            this.IdAlumno = 0;
            this.NombreAlumno = "no hay";
            this.ApellidosAlumno = "no hay";
            this.Beca = 0.0;
            this.IdCurso = 0;
        }
        
        public ClsAlumno(int idAlumno,string nombre,string apellidos,double beca,int idCurso)
        {
            this.IdAlumno = 0;
            this.NombreAlumno = "no hay";
            this.ApellidosAlumno = "no hay";
            this.Beca = 0.0;
            this.IdCurso = 0;
        }

        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidosAlumno { get; set; }
        public double Beca { get; set; }
        public int IdCurso { get; set; }

    }
}