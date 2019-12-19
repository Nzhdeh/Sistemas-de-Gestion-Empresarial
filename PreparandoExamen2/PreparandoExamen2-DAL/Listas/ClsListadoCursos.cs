using PreparandoExamen2_DAL.Conexion;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_DAL.Listas
{
    public class ClsListadoCursos
    {
        public List<ClsCurso> ObtenerListadoCursosDAL()
        {
            ClsMyConnection miConexion;

            List<ClsCurso> listado = new List<ClsCurso>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsCurso oCurso;

            SqlConnection conexion;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM AD_Cursos";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCurso = new ClsCurso();
                        oCurso.IdCurso = (int)miLector["IDCurso"];
                        oCurso.NombreCurso = (string)miLector["NombreCurso"];
                        listado.Add(oCurso);
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