using Examen1TrimestreNzhdeh_DAL.Conexion;
using Examen1TrimestreNzhdeh_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1trimestreNzhdehUWP.Listados
{
    public class ClsListadoDeMisionesNoReservadas
    {
        /// <summary>
        /// sirve para devolver el listado de las misiones no reservadas
        /// </summary>
        /// <returns>
        /// asociado al nombre devuelve la lista de las misiones no reservadas
        /// </returns>
        public List<ClsMision> ListadoDeMisionesNoReservadasDAL()
        {
            ClsMyConnection miConexion = null;

            List<ClsMision> listadoMisiones = new List<ClsMision>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector = null;

            ClsMision oMision = null;

            SqlConnection conexion = null;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM misiones where reservada = 0";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oMision = new ClsMision();
                        oMision.IdMision = (int)miLector["idMision"];
                        oMision.TituloMision = (string)miLector["tituloMision"];
                        oMision.DescripcionMision = (string)miLector["descripcionMision"];
                        oMision.Reservada = (Boolean)miLector["reservada"];
                        
                        //oMision.IdSuperheroe = (int)miLector["idSuperheroe"];
                        //oMision.Observaciones = (string)miLector["observaciones"];
                        listadoMisiones.Add(oMision);
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

            return listadoMisiones;
        }
    }
}
