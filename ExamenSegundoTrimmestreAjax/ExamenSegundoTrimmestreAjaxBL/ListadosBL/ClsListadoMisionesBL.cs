using ExamenSegundoTrimmestreAjaxDAL.ListadosDAL;
using ExamenSegundoTrimmestreAjaxET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSegundoTrimmestreAjaxBL.ListadosBL
{
    public class ClsListadoMisionesBL
    {
        /// <summary>
        /// Recoge de la capa DAL el listado de las misiones de un superheroe y lo pasa a la CAPA UI
        /// </summary>
        /// <param name="id">El id del superheroe </param>
        /// <returns>Devuelve las misiones que sea de ese ID</returns>
        public List<ClsMision> misionesPorIdSuperheroeBL(int id)
        {
            return new ClsListadoMisionesDAL().misionesPorIdSuperheroeDAL(id);
        }
    }
}
