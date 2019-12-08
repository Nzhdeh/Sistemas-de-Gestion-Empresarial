using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_UI.Models
{
    public class ClsAlumnoConListadoDeCursos : ClsAlumno
    {
        public ClsAlumnoConListadoDeCursos() : base()
        {
            this.ListadoCursos = new List<ClsCurso>();
        }

        public ClsAlumnoConListadoDeCursos(List<ClsCurso> listado, ClsAlumno alumno)
            : base(alumno.IdAlumno, alumno.NombreAlumno, alumno.ApellidosAlumno, alumno.Beca, alumno.IdCurso)
        {
            this.ListadoCursos = listado;
        }
        public List<ClsCurso> ListadoCursos { get; set; }
    }
}