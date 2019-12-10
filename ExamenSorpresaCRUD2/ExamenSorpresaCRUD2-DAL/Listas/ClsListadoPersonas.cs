using ExamenSorpresaCRUD2_DAL.Conexion;
using ExamenSorpresaCRUD2_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSorpresaCRUD2_DAL.Listas
{
    public class ClsListadoPersonas
    {
        /// <summary>
        /// Se conecta a la BBDD y devuelve el listado de las personas
        /// </summary>
        /// <returns>Listado de personas List<clsPersona></returns>
        public List<ClsPersona> listadoPersona()
        {
            List<ClsPersona> listado = new List<ClsPersona>();
            ClsMyConnection connection = new ClsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona oPersona;
            //Byte[] bytes = new Byte[20];
            try
            {
                miComando.CommandText = "SELECT * FROM dbo.PD_Personas";
                miComando.Connection = conn;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.IDPersona = (int)miLector["IdPersona"];
                        oPersona.Nombre = (miLector["NombrePersona"] is DBNull) ? "NULL" : (string)miLector["NombrePersona"];
                        oPersona.Apellidos = (miLector["ApellidosPersona"] is DBNull) ? "NULL" : (string)miLector["ApellidosPersona"];
                        oPersona.FechaNacimiento = (miLector["FechaNacimientoPersona"] is DBNull) ? new DateTime() : (DateTime)miLector["FechaNacimientoPersona"];
                        //oPersona.Direccion = ((string)miLector["direccion"] != null) ? (string)miLector["direccion"] : null;
                        oPersona.Telefono = (miLector["TelefonoPersona"] is DBNull) ? "NULL" : (string)miLector["TelefonoPersona"];
                        oPersona.Foto = (miLector["FotoPersona"] is DBNull) ? new byte[1] : (Byte[])miLector["FotoPersona"];
                        oPersona.IDDepartamento = (int)miLector["IDDepartamento"];
                        listado.Add(oPersona);
                    }
                }
                miLector.Close();
                connection.closeConnection(ref conn);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listado;

        }

        /// <summary>
        /// Se conecta a la BBDD y devuelve el listado de personas que tiene esa ID de Departamento
        /// </summary>
        /// <param name="id">El id que tenemos que buscar</param>
        /// <returns>Devolvemos el listado de personas que tiene esa ID de Departamento</returns>
        public List<ClsPersona> personasPorDepartamento(int id)
        {
            List<ClsPersona> listado = new List<ClsPersona>();
            ClsMyConnection connection = new ClsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            try
            {
                miComando.CommandText = "SELECT * FROM dbo.PD_Personas WHERE IDDepartamento = " + id;
                miComando.Connection = conn;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        ClsPersona oPersona = new ClsPersona();
                        oPersona.IDPersona = (int)miLector["IdPersona"];
                        oPersona.Nombre = (miLector["NombrePersona"] is DBNull) ? "NULL" : (string)miLector["NombrePersona"];
                        oPersona.Apellidos = (miLector["ApellidosPersona"] is DBNull) ? "NULL" : (string)miLector["ApellidosPersona"];
                        oPersona.FechaNacimiento = (miLector["FechaNacimientoPersona"] is DBNull) ? new DateTime() : (DateTime)miLector["FechaNacimientoPersona"];
                        //oPersona.Direccion = ((string)miLector["direccion"] != null) ? (string)miLector["direccion"] : null;
                        oPersona.Telefono = (miLector["TelefonoPersona"] is DBNull) ? "NULL" : (string)miLector["TelefonoPersona"];
                        oPersona.Foto = (miLector["FotoPersona"] is DBNull) ? new byte[1] : (Byte[])miLector["FotoPersona"];
                        oPersona.IDDepartamento = (int)miLector["IDDepartamento"];
                        listado.Add(oPersona);
                    }
                }
                miLector.Close();
                connection.closeConnection(ref conn);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listado;
        }

        /// <summary>
        /// Se conecta a la BBDD y devuelve la persona que tiene esa ID
        /// </summary>
        /// <param name="id">El id que tenemos que buscar</param>
        /// <returns>Devolvemos la persona que tiene esa ID</returns>
        public ClsPersona personaporID(int id)
        {
            ClsPersona oPersona = new ClsPersona();
            ClsMyConnection connection = new ClsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            try
            {
                miComando.CommandText = "SELECT * FROM dbo.PD_Personas WHERE idPersona = " + id;
                miComando.Connection = conn;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona.IDPersona = (int)miLector["IdPersona"];
                        oPersona.Nombre = (miLector["NombrePersona"] is DBNull) ? "NULL" : (string)miLector["NombrePersona"];
                        oPersona.Apellidos = (miLector["ApellidosPersona"] is DBNull) ? "NULL" : (string)miLector["ApellidosPersona"];
                        oPersona.FechaNacimiento = (miLector["FechaNacimientoPersona"] is DBNull) ? new DateTime() : (DateTime)miLector["FechaNacimientoPersona"];
                        //oPersona.Direccion = ((string)miLector["direccion"] != null) ? (string)miLector["direccion"] : null;
                        oPersona.Telefono = (miLector["TelefonoPersona"] is DBNull) ? "NULL" : (string)miLector["TelefonoPersona"];
                        oPersona.Foto = (miLector["FotoPersona"] is DBNull) ? new byte[1] : (Byte[])miLector["FotoPersona"];
                        oPersona.IDDepartamento = (int)miLector["IDDepartamento"];
                    }
                }
                miLector.Close();
                connection.closeConnection(ref conn);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return oPersona;
        }
    }
}
