using ExamenSorpresaCRUD_DAL.Connection;
using ExamenSorpresaCRUD_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenSorpresaCRUD_BL.Lists
{
    public class ClsListadoPersonasPorIdDepartamento
    {
        /// <summary>
        /// nos da una lista de los apellidos de las personas que trabajan en un departamento
        /// </summary>
        /// <param name="idDepartamento"> el id de un departamento</param>
        /// <returns>
        /// listado de apellidos de personas
        /// </returns>
        public List<String> ObtenerListadoApellidosPersonaPorIdDepartamento(int idDepartamento)
        {
            ClsMyConnection miConexion;

            List<String> listadoApellidos = new List<String>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona persona;

            SqlConnection conexion;

            String apellidos = "";


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT ApellidosPersona FROM Personas where IdDepartamento = @idDepartamento";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        persona = new ClsPersona();
                        persona.ApellidosPersona = (string)miLector["ApellisosPersona"];
                        apellidos = persona.ApellidosPersona;
                        listadoApellidos.Add(apellidos);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException se)
            {
                throw se;
            }
            return listadoApellidos;
        }
    }
}