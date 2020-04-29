using CuestionarioCoronavirusDAL.ManejadorasDAL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusBL.ManejadorasBL
{
    public class ClsGestionPersonaBL
    {
        /// <summary>
        /// sirve para guardar la persona en la bbdd
        /// </summary>
        /// <param name="persona">la persona que vamos a guardar</param>
        public void InsertarPersonaBL(ClsPersona persona)
        {
            int resultado = 0;
            try
            {
                ClsGestionPersonaDAL gestoraDal = new ClsGestionPersonaDAL();
                resultado = gestoraDal.InsertarPersonaDAL(persona);
            }
            catch (Exception exSql)
            {
                if (resultado == 0)
                {
                    throw exSql;
                }
            }
        }
    }
}
