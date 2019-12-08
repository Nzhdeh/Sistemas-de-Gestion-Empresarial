using PreparandoExamen2_DAL.Conexion;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_DAL.Manejadoras
{
    public class ClsGestoraCursosDAL
    {
        public ClsCurso BuscarCursoPorIdDAL(int id)
        {
            ClsMyConnection miConexion;

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsCurso c = new ClsCurso();

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "SELECT * FROM AD_Cursos WHERE IDCurso = @id";
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
                    c = new ClsCurso();
                    c.IdCurso = (int)miLector["IDCurso"];
                    c.NombreCurso = (string)miLector["NombreCurso"];
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;//aqui salta una excepcion cuando borro
            }

            return c;
        }


        public int BorrarCursoPorIdDAL(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection();
            int resultado = 0;


            try
            {
                miComando.CommandText = "DELETE FROM AD_Cursos WHERE IDCurso = @IDCurso";
                miComando.Parameters.Add("@IDCurso", System.Data.SqlDbType.Int).Value = id;
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


        public int InsertarCursoDAL(ClsCurso curso)
        {
            int resultado = 0;

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();

                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = curso.NombreCurso;

                miComando.CommandText = "INSERT INTO AD_Cursos (NombreCurso) " +
                    "VALUES (@nombre)";

                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }

            return resultado;
        }


        public int ActualizarCursoDAL(ClsCurso curso)
        {
            int resultado = 0;
            try
            {
                ClsMyConnection connection = new ClsMyConnection();
                SqlConnection conn = connection.getConnection();
                SqlCommand miComando = new SqlCommand();
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = curso.IdCurso;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = curso.NombreCurso;

                miComando.CommandText = "UPDATE dbo.AD_Cursos SET NombreCurso = @nombre WHERE IDCurso = @id";
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