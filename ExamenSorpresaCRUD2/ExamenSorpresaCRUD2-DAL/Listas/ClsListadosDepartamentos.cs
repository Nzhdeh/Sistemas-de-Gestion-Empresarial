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
    public class ClsListadosDepartamentos
    {
        /// <summary>
        /// Se conecta a la BBDD y devuelve el listado de los departamentos
        /// </summary>
        /// <returns>Listado de departamentos List<clsDepartamento></returns>
        public List<ClsDepartamento> listadoDpto()
        {
            List<ClsDepartamento> listado = new List<ClsDepartamento>();
            ClsMyConnection connection = new ClsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsDepartamento oDpto;

            try
            {
                miComando.CommandText = "SELECT * FROM dbo.PD_Departamentos";
                miComando.Connection = conn;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDpto = new ClsDepartamento();
                        oDpto.ID = (int)miLector["IDDepartamento"];
                        oDpto.Nombre = (string)miLector["NombreDepartamento"];
                        listado.Add(oDpto);
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
    }
}
