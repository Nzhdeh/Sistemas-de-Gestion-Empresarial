using PreparandoExamen2_DAL.Conexion;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_DAL.Manejadoras
{
    public class ClsGestoraAlumnosDAL
    {
        public ClsAlumno BuscarAlumnoPorIdDAL(int idAlumno)
        {
            ClsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsAlumno a = new ClsAlumno();

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "SELECT * FROM AD_Alumnos WHERE ID = @idAlumno";
                parameter = new SqlParameter();
                parameter.ParameterName = "@idAlumno";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = idAlumno;
                miComando.Parameters.Add(parameter);

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    a = new ClsAlumno();
                    a.IdAlumno = (int)miLector["ID"];
                    a.NombreAlumno = (string)miLector["NombreAlumno"];
                    a.ApellidosAlumno = (string)miLector["ApellidosAlumno"];
                    a.Beca = (int)miLector["Beca"];
                    a.IdCurso = (int)miLector["IDCurso"];
                    
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;//aqui salta una excepcion cuando borro
            }

            return a;
        }

       
        public int BorrarAlumnoPorIdDAL(int idAlumno)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection();
            int resultado = 0;
            

            try
            {
                miComando.CommandText = "DELETE FROM AD_Alumnos WHERE ID = @IDAlumno";
                miComando.Parameters.Add("@IDAlumno", System.Data.SqlDbType.Int).Value = idAlumno;
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


        public int InsertarAlumnoDAL(ClsAlumno alumno)
        {
            int resultado = 0;

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();

                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = alumno.NombreAlumno;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = alumno.ApellidosAlumno;
                miComando.Parameters.Add("@beca", System.Data.SqlDbType.Decimal).Value = alumno.Beca;
                miComando.Parameters.Add("@IdCurso", System.Data.SqlDbType.Int).Value = alumno.IdCurso;
                



                miComando.CommandText = "INSERT INTO AD_Alumnos (NombreAlumno, ApellidosAlumno, Beca, IdCurso) " +
                    "VALUES (@nombre, @apellidos, @beca, @IdCurso)";


                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }

            return resultado;
        }


        public int ActualizarAlumnoDAL(ClsAlumno alumno)
        {
            int resultado = 0;
            try
            {
                ClsMyConnection connection = new ClsMyConnection();
                SqlConnection conn = connection.getConnection();
                SqlCommand miComando = new SqlCommand();
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = alumno.IdAlumno;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = alumno.NombreAlumno;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = alumno.ApellidosAlumno;
                miComando.Parameters.Add("@beca", System.Data.SqlDbType.Decimal).Value = alumno.Beca;
                miComando.Parameters.Add("@IdCurso", System.Data.SqlDbType.Int).Value = alumno.IdCurso;

                //miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.foto = new byte[10];


                miComando.CommandText = "UPDATE dbo.AD_Alumnos SET NombreAlumno = @nombre, ApellidosAlumno = @apellidos, Beca=@beca, IdCurso = @IdCurso WHERE IdAlumno = @id";
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