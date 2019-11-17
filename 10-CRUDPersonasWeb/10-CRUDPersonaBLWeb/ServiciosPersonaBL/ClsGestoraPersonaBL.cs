using _10_CRUDPersonaEntidadesWeb;
using _10_CRUDPersonaDalWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CRUDPersonaBLWeb.ServiciosPersonaBL
{
    public class ClsGestoraPersonaBL
    {

        ClsGestoraPersonaDAL gestoraPersonaDAL;//se puede meter  en cada metodo que usa esta gestora

        /// <summary>
        /// busca una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// entero id
        /// </returns>
        public ClsPersona BuscarPersonaPorId(int id)
        {
            ClsPersona persona;
            gestoraPersonaDAL = new ClsGestoraPersonaDAL();
            persona = gestoraPersonaDAL.buscarPersonaPorId(id);

            return persona;
        }

        /// <summary>
        /// actualiza los datos de una persona 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>
        /// una persona
        /// </returns>
        public int ActualizarPersona(ClsPersona persona)
        {
            int resultado = 0;
            ClsGestoraPersonaDAL gestoraPersonaDAL = new ClsGestoraPersonaDAL();
            resultado = gestoraPersonaDAL.updatePersonaDAL(persona);

            return resultado;
        }

        /// <summary>
        /// elimina una persona de la bbdd
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// entero id
        /// </returns>
        public int BorrarPersonaPorId(int id)
        {
            int resultado = 0;
            ClsGestoraPersonaDAL gestoraPersonaDAL = new ClsGestoraPersonaDAL();
            resultado = gestoraPersonaDAL.deletePersona(id);

            return resultado;
        }

        /// <summary>
        /// inserta una persona a la bbdd
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>
        /// una persona
        /// </returns>
        public int InsertarPersona(ClsPersona persona)
        {
            int resultado = 0;

            ClsGestoraPersonaDAL gestoraPersonaDAL = new ClsGestoraPersonaDAL();
            resultado = gestoraPersonaDAL.addPersonaDAL(persona);

            return resultado;
        }
    }
}
