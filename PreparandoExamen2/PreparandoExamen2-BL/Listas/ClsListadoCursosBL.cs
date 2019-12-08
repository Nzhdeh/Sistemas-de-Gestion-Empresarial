using PreparandoExamen2_DAL.Listas;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_BL.Listas
{
    public class ClsListadoCursosBL
    {
        public List<ClsCurso> ObtenerListadoCursosBL()
        {
            ClsListadoCursos dal = new ClsListadoCursos();
            List<ClsCurso> listado = dal.ObtenerListadoCursosDAL();

            return listado;
        }
    }
}
