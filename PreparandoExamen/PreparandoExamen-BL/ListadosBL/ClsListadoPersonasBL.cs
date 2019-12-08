using PreparandoExamen_DAL.ListadosDAL;
using PreparandoExamen_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen_BL.ListadosBL
{
    public class ClsListadoPersonasBL
    {
        public List<ClsPersona> ObtenerListadoPersonasBL()
        {
            List<ClsPersona> lista;

            ClsListadoPersonasDAL listadoPersonasDAL = new ClsListadoPersonasDAL();

            lista = listadoPersonasDAL.ObtenerListadoPersonasDAL();

            return lista;
        }
    }
}