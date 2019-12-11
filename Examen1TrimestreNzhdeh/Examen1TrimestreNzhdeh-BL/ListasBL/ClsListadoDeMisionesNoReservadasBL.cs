using Examen1TrimestreNzhdeh_ET;
using Examen1trimestreNzhdehUWP.Listados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1TrimestreNzhdeh_BL.ListasBL
{
    public class ClsListadoDeMisionesNoReservadasBL
    {
        /// <summary>
        /// sirve para devolver el listado de las misiones no reservadas
        /// </summary>
        /// <returns>
        /// asociado al nombre devuelve la lista de las misiones no reservadas
        /// </returns>
        public List<ClsMision> ListadoDeMisionesNoReservadasBL()
        {
            List<ClsMision> listado = new List<ClsMision>();
            ClsListadoDeMisionesNoReservadas dal = new ClsListadoDeMisionesNoReservadas();

            listado = dal.ListadoDeMisionesNoReservadasDAL();

            return listado;
        }
    }
}
