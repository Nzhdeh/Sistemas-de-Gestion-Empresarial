using Examen1TrimestreNzhdeh_DAL.Conexion;
using Examen1TrimestreNzhdeh_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1TrimestreNzhdeh_DAL.ListasDAL
{
    public class ClsListadoDeVengadores
    {
        /// <summary>
        /// sirve para devolver el listado de todos los vengadores 
        /// </summary>
        /// <returns>
        /// asociado al nombre devuelve la lista de los vengadores 
        /// </returns>
        public List<ClsSuperheroe> ListadoCompletoVengadoresDAL()
        {
            ClsMyConnection miConexion = null;

            List<ClsSuperheroe> listadoVengadores = new List<ClsSuperheroe>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector = null;

            ClsSuperheroe oVengadores = null;

            SqlConnection conexion = null;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM superheroes";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oVengadores = new ClsSuperheroe();
                        oVengadores.IdSuperheroe = (int)miLector["idSuperheroe"];
                        oVengadores.NombreSuperheroe = (string)miLector["nombreSuperheroe"];
                       
                        listadoVengadores.Add(oVengadores);
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

                if (miConexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return listadoVengadores;
        }
    }
}
