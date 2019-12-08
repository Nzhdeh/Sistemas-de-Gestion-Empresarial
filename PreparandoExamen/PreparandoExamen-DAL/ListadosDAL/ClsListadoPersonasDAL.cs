using PreparandoExamen_DAL.Conexion;
using PreparandoExamen_ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreparandoExamen_DAL.ListadosDAL
{
    public class ClsListadoPersonasDAL
    {
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
                miComando.CommandText = "SELECT * FROM PD_Personas";

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
                        oPersona.IdDepartamento = (int)miLector["IdDepartamento"];
                        oPersona.TelefonoPersona = (string)miLector["TelefonoPersona"];
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