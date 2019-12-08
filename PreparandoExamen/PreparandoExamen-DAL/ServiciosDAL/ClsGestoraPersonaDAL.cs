using PreparandoExamen_DAL.Conexion;
using PreparandoExamen_ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreparandoExamen_DAL.ServiciosDAL
{
    public class ClsGestoraPersonaDAL
    {
        public ClsPersona BuscarPersonaPorIdDAL(int id)
        {
            ClsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona = new ClsPersona();

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                
                miComando.CommandText = "SELECT * FROM PD_Personas WHERE IDPersona = @id";
                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;
                miComando.Parameters.Add(parameter);

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    oPersona = new ClsPersona();
                    oPersona.IdPersona = (int)miLector["IdPersona"];
                    oPersona.NombrePersona = (string)miLector["NombrePersona"];
                    oPersona.ApellidosPersona = (string)miLector["ApellidosPersona"];
                    oPersona.FechaNacimientoPersona = (DateTime)miLector["FechaNacimientoPersona"];
                    oPersona.IdDepartamento = (int)miLector["IDDepartamento"];
                    oPersona.TelefonoPersona = (string)miLector["TelefonoPersona"];
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;//aqui salta una excepcion cuando borro
            }

            return oPersona;            
        }

        /// <summary>
        /// borra a una perosna por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public int BorrarPersonaPorIdDAL(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection(); ;
            int resultado = 0;
            miComando.CommandText = "DELETE FROM PD_Personas WHERE IdPersona = @IdPersona";
            miComando.Parameters.Add("@IdPersona", System.Data.SqlDbType.Int).Value = id;

            try
            {
                conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }


            return resultado;
        }


        public int InsertarPersonaDAL(ClsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();

                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
                miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.FechaNacimientoPersona;
                miComando.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;


            
                miComando.CommandText = "INSERT INTO PD_Personas (NombrePersona, ApellidosPersona, FechaNacimientoPersona, IdDepartamento, TelefonoPersona) " +
                    "VALUES (@nombre, @apellidos, @fechaNac, @IdDepartamento, @telefono)";

                
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }

            return resultado;
        }


        public int ActualizarPersonaDAL(ClsPersona persona)
        {
            int resultado = 0;
            try
            {
                ClsMyConnection connection = new ClsMyConnection();
                SqlConnection conn = connection.getConnection();
                SqlCommand miComando = new SqlCommand();
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.IdPersona;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
                miComando.Parameters.Add("@idDpto", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimientoPersona;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;
                //miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.foto = new byte[10];


                miComando.CommandText = "UPDATE dbo.PD_Personas SET NombrePersona = @nombre, ApellidosPersona = @apellidos, IDDepartamento = @idDpto, FechaNacimientoPersona =  @fechaNacimiento, TelefonoPersona = @telefono WHERE IdPersona = @id";
                miComando.Connection = conn;
                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;

        }
    }
}