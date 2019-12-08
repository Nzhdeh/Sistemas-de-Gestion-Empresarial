using PreparandoExamen2_DAL.Conexion;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_DAL.Listas
{
    public class ClsListadoAlumnos
    {
        public List<ClsAlumno> ObtenerListadoAlumnosDAL()
        {
            ClsMyConnection miConexion;

            List<ClsAlumno> listado = new List<ClsAlumno>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsAlumno oAlumno;

            SqlConnection conexion;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM AD_Alumnos";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oAlumno = new ClsAlumno();
                        oAlumno.IdAlumno = (int)miLector["ID"];
                        oAlumno.NombreAlumno = (string)miLector["NombreAlumno"];
                        oAlumno.ApellidosAlumno = (string)miLector["ApellidosAlumno"];
                        oAlumno.Beca = (int)miLector["Beca"];
                        oAlumno.IdCurso = (int)miLector["IdCurso"];
                        listado.Add(oAlumno);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listado;
        }
    }
}