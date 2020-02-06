using ExamenSegundoTrimmestreAjaxDAL.Conexion;
using ExamenSegundoTrimmestreAjaxET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSegundoTrimmestreAjaxDAL.ListadosDAL
{
    public class ClsListadoMisionesDAL
    {
        /// <summary>
        /// Se conecta a la BBDD y devuelve el listado de las misiones de un superheroe
        /// </summary>
        /// <param name="id">El id que tenemos que buscar</param>
        /// <returns>Devolvemos el listado de misionezs que tiene esa ID de Superheroe</returns>
        public List<ClsMision> misionesPorIdSuperheroeDAL(int id)
        {
            List<ClsMision> listado = new List<ClsMision>();
            ClsMyConnection connection = new ClsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            try
            {
                miComando.CommandText = "SELECT * FROM dbo.misiones WHERE idSuperheroe = " + id;
                miComando.Connection = conn;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        ClsMision oMision = new ClsMision();
                        oMision.IdMision = (int)miLector["idMision"];
                        oMision.TituloMision = (miLector["tituloMision"] is DBNull) ? "NULL" : (string)miLector["tituloMision"];
                        oMision.DescripcionMision = (miLector["descripcionMision"] is DBNull) ? "NULL" : (string)miLector["descripcionMision"];
                        oMision.Reservada = (miLector["reservada"] is DBNull) ? false : (bool)miLector["TelefonoPersona"];
                        oMision.IdSuperheroe = (int)miLector["idSuperheroe"];
                        oMision.Observaciones= (miLector["observaciones"] is DBNull) ? "NULL" : (string)miLector["observaciones"];
                        listado.Add(oMision);
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
