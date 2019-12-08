using PreparandoExamen2_DAL.Manejadoras;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_BL.Manejadoras
{
    public class ClsGestoraAlumnosBL
    {
        public ClsAlumno BuscarAlumnoPorIdBL(int idAlumno)
        {
            ClsGestoraAlumnosDAL g = new ClsGestoraAlumnosDAL();
            ClsAlumno a = new ClsAlumno();

            a = g.BuscarAlumnoPorIdDAL(idAlumno);

            return a;
        }


        public int BorrarAlumnoPorIdBL(int idAlumno)
        {
            ClsGestoraAlumnosDAL g = new ClsGestoraAlumnosDAL();
            int resultado = 0;

            resultado = g.BorrarAlumnoPorIdDAL(idAlumno);

            return resultado;
        }


        public int InsertarAlumnoBL(ClsAlumno alumno)
        {
            ClsGestoraAlumnosDAL g = new ClsGestoraAlumnosDAL();
            int resultado = 0;

            resultado = g.InsertarAlumnoDAL(alumno);

            return resultado;
        }


        public int ActualizarAlumnoBL(ClsAlumno alumno)
        {
            ClsGestoraAlumnosDAL g = new ClsGestoraAlumnosDAL();
            int resultado = 0;

            resultado = g.ActualizarAlumnoDAL(alumno);

            return resultado;
        }
    }
}