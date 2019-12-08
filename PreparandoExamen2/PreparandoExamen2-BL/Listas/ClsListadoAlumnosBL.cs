using PreparandoExamen2_DAL.Listas;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_BL.Listas
{
    public class ClsListadoAlumnosBL
    {

        public List<ClsAlumno> ObtenerListadoAlumnosBL()
        {
            ClsListadoAlumnos dal = new ClsListadoAlumnos();
            List<ClsAlumno> listado = dal.ObtenerListadoAlumnosDAL();

            return listado;
        }
    }
}