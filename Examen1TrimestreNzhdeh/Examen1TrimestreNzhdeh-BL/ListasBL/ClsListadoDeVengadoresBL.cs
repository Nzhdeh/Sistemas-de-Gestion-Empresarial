using Examen1TrimestreNzhdeh_DAL.ListasDAL;
using Examen1TrimestreNzhdeh_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1TrimestreNzhdeh_BL.ListasBL
{
    public class ClsListadoDeVengadoresBL
    {
        /// <summary>
        /// sirve para devolver el listado de todos los vengadores 
        /// </summary>
        /// <returns>
        /// asociado al nombre devuelve la lista de los vengadores 
        /// </returns>
        public List<ClsSuperheroe> ListadoCompletoVengadoresBL()
        {
            List<ClsSuperheroe> listadoVengadores = new List<ClsSuperheroe>();
            ClsListadoDeVengadores dal = new ClsListadoDeVengadores();

            listadoVengadores = dal.ListadoCompletoVengadoresDAL();

            return listadoVengadores;
        }
    }
}
