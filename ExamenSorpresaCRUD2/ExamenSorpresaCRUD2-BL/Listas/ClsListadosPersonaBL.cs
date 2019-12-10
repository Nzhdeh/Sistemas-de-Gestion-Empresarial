using ExamenSorpresaCRUD2_DAL.Listas;
using ExamenSorpresaCRUD2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSorpresaCRUD2_BL.Listas
{
    public class ClsListadosPersonaBL
    {
        /// <summary>
        /// Recoge de la capa DAL el listado y lo pasa a la CAPA UI
        /// </summary>
        /// <returns>El listado de personas List<clsPersona></returns>
        public List<ClsPersona> listadoPersonas()
        {
            ClsListadoPersonas listBBDD = new ClsListadoPersonas();
            List<ClsPersona> listado = new List<ClsPersona>();
            listado = listBBDD.listadoPersona();
            return listado;
        }

        /// <summary>
        /// Recoge de la capa DAL el listado y lo pasa a la CAPA UI
        /// </summary>
        /// <param name="id">El id del departamento a buscar</param>
        /// <returns>Devuelve las personsa que sea de ese ID</returns>
        public List<ClsPersona> personasPorIDDepartamento(int id)
        {
            ClsListadoPersonas listBBDD = new ClsListadoPersonas();
            List<ClsPersona> personas = new List<ClsPersona>();
            personas = listBBDD.personasPorDepartamento(id);
            return personas;
        }

        /// <summary>
        /// Recoge de la capa DAL el listado y lo pasa a la CAPA UI
        /// </summary>
        /// <param name="id">El id de la persona a buscar</param>
        /// <returns>Devuelve la persona que sea de ese ID</returns>
        public ClsPersona personaPorID(int id)
        {
            ClsListadoPersonas listBBDD = new ClsListadoPersonas();
            ClsPersona persona = new ClsPersona();
            persona = listBBDD.personaporID(id);
            return persona;
        }
    }
}
