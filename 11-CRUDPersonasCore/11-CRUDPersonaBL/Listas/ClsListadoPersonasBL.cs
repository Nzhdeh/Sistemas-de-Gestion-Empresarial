using _11_CRUDPersonaDAL.Listados;
using _11_CRUDPersonaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_CRUDPersonaBL.Listas
{
    public class ClsListadoPersonasBL
    {
        public List<ClsPersona> ListadoPersonas()
        {
            List<ClsPersona> lista;

            ClsListadoPersonasDAL listadoPersonasDAL = new ClsListadoPersonasDAL();

            lista = listadoPersonasDAL.ObtenerListadoPersonasDAL();

            return lista;
        }
    }
}
