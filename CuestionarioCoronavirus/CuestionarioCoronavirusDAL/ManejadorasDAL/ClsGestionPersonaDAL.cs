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
    public class ClsGestionPersonaDAL
    {
        /// <summary>
        /// sirve para insertar una persona en la bbdd
        /// </summary>
        /// <param name="persona">la persona que vamos a guardar</param>
        /// <returns>un 0 si hay problemas de conexion, 0 si algun campo no esta rellenado y un numero mayor que 0 si todo va bien</returns>
        public int InsertarPersonaDAL(ClsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion=null;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@dniPersona", System.Data.SqlDbType.VarChar).Value = persona.DniPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
            miComando.Parameters.Add("@apellidosPersona", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPerson;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@diagnostico", System.Data.SqlDbType.VarChar).Value = Convert.ToString(persona.Diagnostico).ToLower();


            try
            {
                miComando.CommandText = "insert into CV_Personas(dniPersona,nombrePersona,apellidosPersona,telefono,direccion,diagnostico) " +
                                       "values(@dniPersona, @nombre,@apellidosPersona,@telefono,@direccion,@diagnostico)";

                conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return resultado;
        }
    }
}
