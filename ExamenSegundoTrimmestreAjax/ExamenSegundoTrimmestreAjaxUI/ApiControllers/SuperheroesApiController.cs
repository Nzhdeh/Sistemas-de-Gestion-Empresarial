using ExamenSegundoTrimmestreAjaxBL.ListadosBL;
using ExamenSegundoTrimmestreAjaxET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ExamenSegundoTrimmestreAjaxUI.ApiControllers
{
    public class SuperheroesApiController : ApiController
    {
        /// <summary>
        /// obtiene el listado de los superheroes
        /// </summary>
        /// <returns></returns>
        public List<ClsSuperheroe> Get()
        {
            return new ClsListadoSuperheroesBL().obtenerListadoSuperheroesBL();
        }

        /// <summary>
        /// obtiene a un superheroe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClsSuperheroe Get(int id)
        {
            return new ClsListadoSuperheroesBL().obtenerSuperheroePorIdBL(id);
        }
    }
}