using _11_CRUDPersonaDAL.Listados;
using _11_CRUDPersonaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_CRUDPersonaBL.Listas
{
    public class ClsListadoDepartamentosBL
    {
        public List<ClsDepartamento> ObtenerListadoDepartamentosBL()
        {
            List<ClsDepartamento> lista;

            ClsListadoDepartamentosDAL listadoDepartamentosDAL = new ClsListadoDepartamentosDAL();

            lista = listadoDepartamentosDAL.ObtenerListadoDepartamentosDAL();

            return lista;

        }
    }
}
