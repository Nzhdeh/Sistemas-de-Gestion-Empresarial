using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CRUDPersonaBLWeb.Listados
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
