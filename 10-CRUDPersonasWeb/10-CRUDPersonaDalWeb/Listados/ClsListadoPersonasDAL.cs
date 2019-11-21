using _10_CRUDPersonaDalWeb.Conexion;
using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CRUDPersonaDalWeb.Listados
{
    public class ClsListadoPersonasDAL
    {
        /// <summary>
        /// devuelve la lista de persona que estan en la base de datos
        /// </summary>
        /// <returns>
        /// postcondiciones: AN devuelve listado de personas
        /// </returns>
        public List<ClsPersona> ObtenerListadoPersonasDAL()
        {
            ClsMyConnection miConexion;

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            SqlConnection conexion;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Personas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.IdPersona = (int)miLector["IDPersona"];
                        oPersona.NombrePersona = (string)miLector["NombrePersona"];
                        oPersona.ApellidosPersona = (string)miLector["ApellidosPersona"];
                        oPersona.FechaNacimientoPersona = (DateTime)miLector["FechaNacimientoPersona"];
                        oPersona.TelefonoPersona = (string)miLector["TelefonoPersona"];
                        oPersona.FotoPersona = null;//hay que recuperar la imagen
                        listadoPersonas.Add(oPersona);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoPersonas;
        }
    }
}
