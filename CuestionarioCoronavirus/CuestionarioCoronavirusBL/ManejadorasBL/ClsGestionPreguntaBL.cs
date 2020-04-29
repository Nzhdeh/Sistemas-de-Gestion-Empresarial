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
    public class ClsGestionPreguntaBL
    {

        /// <summary>
        /// sirve para obtener la poregunta pasandole una id
        /// </summary>
        /// <param name="id">la is de la pregunta que queremos obtener</param>
        /// <returns>objeto pregunta</returns>
        public ClsPregunta ObtenerPreguntaPorId(int id)
        {
            ClsPregunta oPregunta = null;
            try
            {
                oPregunta = new ClsGestionPreguntaDAL().ObtenerPreguntaPorId(id);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return oPregunta;
        }
    }
}
