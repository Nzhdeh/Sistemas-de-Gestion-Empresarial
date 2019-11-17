using _10_CRUDPersonaDalWeb.Conexion;
using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CRUDPersonaDalWeb.Listados
{
    public class ClsListadoDepartamentosDAL
    {
        /// <summary>
        /// sirve para obtener el listado de departamentos 
        /// </summary>
        /// <returns>
        /// AN devuelve listado de departamenos
        /// </returns>
        public List<ClsDepartamento> ObtenerListadoDepartamentosDAL()
        {
            ClsMyConnection miConexion;

            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsDepartamento departamento;

            SqlConnection conexion;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM departamentos";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new ClsDepartamento();
                        departamento.IdDepartamentoa = (int)miLector["ID"];
                        departamento.NombreDepartamento = (string)miLector["Nombre"];
                        listadoDepartamentos.Add(departamento);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException se)
            {
                throw se;
            }
            return listadoDepartamentos;
        }
    }
}
