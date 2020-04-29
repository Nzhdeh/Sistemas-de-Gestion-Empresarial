using CuestionarioCoronavirusDAL.Conexion;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusDAL.ManejadorasDAL
{
    public class ClsGestionPreguntaDAL
    {
        /// <summary>
        /// sirve para obtener la poregunta pasandole una id
        /// </summary>
        /// <param name="id">la is de la pregunta que queremos obtener</param>
        /// <returns>objeto pregunta o un null</returns>
        public ClsPregunta ObtenerPreguntaPorId(int id)
        {
            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            ClsPregunta oPregunta = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select * from CV_Preguntas where idPregunta = " + id;

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPregunta = new ClsPregunta();

                        oPregunta.IdPregunta = (int)miLector["idPregunta"];

                        if (!String.IsNullOrEmpty(miLector["pregunta"].ToString()))
                        {
                            oPregunta.Pregunta = (string)miLector["pregunta"];
                        }
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                if (miLector != null)
                    miLector.Close();

                if (conexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return oPregunta;
        }
    }
}
