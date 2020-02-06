using ExamenSegundoTrimmestreAjaxDAL.ListadosDAL;
using ExamenSegundoTrimmestreAjaxET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSegundoTrimmestreAjaxBL.ListadosBL
{
    public class ClsListadoSuperheroesBL
    {
       /// <summary>
       /// sirve `parta devolver el listado de todos los superheroes
       /// </summary>
       /// <returns>listado de superheroes</returns>
        public List<ClsSuperheroe> obtenerListadoSuperheroesBL()
        {
            return new ClsListadoSuperheroesDAL().obtenerListadoDeSuperheroesDAL();
        }

        /// <summary>
        /// sirve para buscar un superheroe por su id
        /// </summary>
        /// <param name="id">el id del superheroe buscado</param>
        /// <returns>un superheroe</returns>
        public ClsSuperheroe obtenerSuperheroePorIdBL(int id)
        {
            return new ClsListadoSuperheroesDAL().obtenerSuperheroePorIdDAL(id);
        }

    }
}
