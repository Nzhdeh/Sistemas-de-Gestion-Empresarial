using ExamenSorpresaCRUD2_DAL.Listas;
using ExamenSorpresaCRUD2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSorpresaCRUD2_BL.Listas
{
    public class ClsListadosDepartamentosBL
    {
        /// <summary>
        /// Recoge de la capa DAL el listado y lo pasa a la CAPA UI
        /// </summary>
        /// <returns>El listado de departamentos List<clsDepartamento></returns>
        public List<ClsDepartamento> listadoDepartamentos()
        {
            ClsListadosDepartamentos listBBDD = new ClsListadosDepartamentos();
            List<ClsDepartamento> listado = new List<ClsDepartamento>();
            listado = listBBDD.listadoDpto();
            return listado;
        }
    }
}
