using ExamenSegundoTrimmestreAjaxDAL.Conexion;
using ExamenSegundoTrimmestreAjaxET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSegundoTrimmestreAjaxDAL.ListadosDAL
{
    public class ClsListadoSuperheroesDAL
    {
        /// <summary>
        /// sirve para obtener la lista de todos los superheroes
        /// </summary>
        /// <returns>listado de los superheroes</returns>
        public List<ClsSuperheroe> obtenerListadoDeSuperheroesDAL()
        {
            List<ClsSuperheroe> listado = new List<ClsSuperheroe>();
            SqlDataReader miLector = null;
            ClsMyConnection clsMyConnection = new ClsMyConnection();
            SqlConnection connection = null;
            try
            {
                connection = clsMyConnection.getConnection();
                SqlCommand sqlCommand = new SqlCommand();

                ClsSuperheroe heroe;


                sqlCommand.CommandText = "SELECT * FROM superheroes";
                sqlCommand.Connection = connection;

                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        heroe = new ClsSuperheroe();
                        heroe.IdSuperheroe = (int)miLector["idSuperheroe"];
                        heroe.NombreSuperheroe = (miLector["nombreSuperheroe"] is DBNull) ? "DEFAULT" : (string)miLector["nombreSuperheroe"];
                        listado.Add(heroe);
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (miLector != null)
                {
                    miLector.Close();
                }

                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);
                }
            }

            return listado;
        }


        /// <summary>
        /// sirve para buscar un superheroe por su id
        /// </summary>
        /// <param name="id">el id del superheroe buscado</param>
        /// <returns>un superheroe</returns>
        public ClsSuperheroe obtenerSuperheroePorIdDAL(int id)
        {
            ClsMyConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector=null;
            SqlConnection conexion=null;
            SqlParameter parameter=null;
            ClsSuperheroe heroe = new ClsSuperheroe();

            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                SqlCommand sqlCommand = new SqlCommand();

                
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;

                sqlCommand.CommandText = "SELECT * FROM superheroes where idSuperheroe = @id";
                sqlCommand.Connection = conexion;

                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    heroe = new ClsSuperheroe();
                    heroe.IdSuperheroe = (int)miLector["idSuperheroe"];
                    heroe.NombreSuperheroe = (miLector["nombreSuperheroe"] is DBNull) ? "DEFAULT" : (string)miLector["nombreSuperheroe"];
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (miLector != null)
                {
                    miLector.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return heroe;
        }
    }
}
