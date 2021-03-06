﻿using _10_CRUDPersonaDalWeb.Conexion;
using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CRUDPersonaDalWeb.ServiciosPersonaDAL
{
    public class ClsGestoraPersonaDAL
    {
        /// <summary>
        /// sirve para buscar a una persona por su id
        /// entrada: un entero
        /// precondiciones: id valido
        /// postcondiciones: AN devuelve un objeto persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// devuelve una persona
        /// </returns>
        public ClsPersona BuscarPersonaPorId(int id)
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
                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;
                miComando.CommandText = "SELECT * FROM personas WHERE IDPersona = @id";
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
                    //oPersona.FotoPersona = (string)miLector["FotoPersona"];
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
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int ActualizarPersonaDAL(ClsPersona persona)
        {

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection(); ;
            int resultado = 0;
            miComando.CommandText = "update personas set NombrePersona=@NombrePersona, ApellidosPersona=@ApellidosPersona, FechaNacimientoPersona=@FechaNacimientoPersona, TelefonoPersona=@TelefonoPersona, FotoPersona=@FotoPersona WHERE IDPersona = @IdPersona";
            miComando.Parameters.Add("@IdPersona", System.Data.SqlDbType.Int).Value = persona.IdPersona;
            miComando.Parameters.Add("@NombrePersona", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
            miComando.Parameters.Add("@ApellidosPersona", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
            miComando.Parameters.Add("@FechaNacimientoPersona", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimientoPersona;
            miComando.Parameters.Add("@TelefonoPersona", System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;
            miComando.Parameters.Add("@FotoPersona", System.Data.SqlDbType.Int).Value = persona.FotoPersona;

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

        /// <summary>
        /// elimina una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// entero id
        /// </returns>
        public int BorrarPersonaPorId(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection(); ;
            int resultado = 0;
            miComando.CommandText = "DELETE FROM personas WHERE IDPersona = @IdPersona";
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

        /// <summary>
        /// inserta una persona en la bbdd
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>
        ///
        /// </returns>
        public int InsertarPersonaDAL(ClsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection();
            
            miComando.Parameters.Add("@NombrePersona", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
            miComando.Parameters.Add("@ApellidosPersona", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
            miComando.Parameters.Add("@IDDepartamennto", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
            miComando.Parameters.Add("@TelefonoPersona", System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;
            miComando.Parameters.Add("@FechaNacimientoPersona", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimientoPersona;
            miComando.Parameters.Add("@FotoPersona", System.Data.SqlDbType.VarBinary).Value = persona.FotoPersona;

            


            try
            {
                miComando.CommandText = "INSERT INTO personas (NombrePersona, ApellidosPersona,IDDepartamento, FechaNacimientoPersona, TelefonoPersona,FotoPersona) " +
                    "VALUES (@NombrePersona, @ApellidosPersona,@IDDepartamento, @FechaNacimientoPersona, @TelefonoPersona,@FotoPersona)";

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
    }
}
