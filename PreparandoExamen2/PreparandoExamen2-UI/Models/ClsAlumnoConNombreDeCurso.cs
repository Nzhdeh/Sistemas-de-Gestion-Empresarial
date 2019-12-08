using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_UI.Models
{
    public class ClsAlumnoConNombreDeCurso: ClsAlumno
    {
        public ClsAlumnoConNombreDeCurso():base()
        {
            this.NombreCurso = "no hay";
        }

        public ClsAlumnoConNombreDeCurso(string nombreCurso,ClsAlumno alumno) 
            : base(alumno.IdAlumno, alumno.NombreAlumno, alumno.ApellidosAlumno, alumno.Beca, alumno.IdAlumno)
        {
            this.NombreCurso = nombreCurso;
        }

        public string NombreCurso { get; set; }
    }
}