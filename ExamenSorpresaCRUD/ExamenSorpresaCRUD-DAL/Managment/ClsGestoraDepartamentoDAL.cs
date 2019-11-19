using ExamenSorpresaCRUD_DAL.Connection;
using ExamenSorpresaCRUD_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSorpresaCRUD_DAL.Managment
{
    public class ClsGestoraDepartamentoDAL
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public ClsDepartamento buscarDepartamentoPorID(int id)
        //{

        //    ClsMyConnection miConexion;


        //    SqlCommand miComando = new SqlCommand();

        //    SqlDataReader miLector;

        //    ClsDepartamento oDepartamento = null;

        //    SqlConnection conexion;

        //    SqlParameter parameter;


        //    miConexion = new ClsMyConnection();
        //    try
        //    {
        //        conexion = miConexion.getConnection();
        //        miComando.CommandText = "SELECT * FROM departamentos WHERE ID = @id";
        //        parameter = new SqlParameter();
        //        parameter.ParameterName = "@id";
        //        parameter.SqlDbType = System.Data.SqlDbType.Int;
        //        parameter.Value = id;
        //        miComando.Parameters.Add(parameter);


        //        miComando.Connection = conexion;
        //        miLector = miComando.ExecuteReader();

        //        //Si hay lineas en el lector
        //        if (miLector.HasRows)
        //        {
        //            miLector.Read();
        //            oDepartamento = new ClsDepartamento();
        //            oDepartamento.IdDepartamentoa = (int)miLector["IdDepartamento"];
        //            oDepartamento.NombreDepartamento = (string)miLector["NombreDepartamento"];
        //        }

        //        miLector.Close();
        //        miConexion.closeConnection(ref conexion);
        //    }

        //    catch (SqlException exSql)
        //    {
        //        throw exSql;
        //    }

        //    return (oDepartamento);

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="nombre"></param>
        ///// <returns></returns>

        //public ClsDepartamento buscarDepartamentoPorNombre(String nombre)
        //{

        //    ClsMyConnection miConexion;


        //    SqlCommand miComando = new SqlCommand();

        //    SqlDataReader miLector;

        //    ClsDepartamento oDepartamento = null;

        //    SqlConnection conexion;

        //    SqlParameter parameter;


        //    miConexion = new ClsMyConnection();
        //    try
        //    {
        //        conexion = miConexion.getConnection();
        //        miComando.CommandText = "SELECT * FROM departamentos WHERE nombre = @nombre";
        //        parameter = new SqlParameter();
        //        parameter.ParameterName = "@nombre";
        //        parameter.SqlDbType = System.Data.SqlDbType.VarChar;
        //        parameter.Value = nombre;
        //        miComando.Parameters.Add(parameter);


        //        miComando.Connection = conexion;
        //        miLector = miComando.ExecuteReader();

        //        //Si hay lineas en el lector
        //        if (miLector.HasRows)
        //        {
        //            miLector.Read();
        //            oDepartamento = new ClsDepartamento();
        //            oDepartamento.IdDepartamentoa = (int)miLector["IdDepartamento"];
        //            oDepartamento.NombreDepartamento = (string)miLector["NombreDepartamento"];
        //        }

        //        miLector.Close();
        //        miConexion.closeConnection(ref conexion);
        //    }

        //    catch (SqlException exSql)
        //    {
        //        throw exSql;
        //    }

        //    return (oDepartamento);

        //}
    }
}
