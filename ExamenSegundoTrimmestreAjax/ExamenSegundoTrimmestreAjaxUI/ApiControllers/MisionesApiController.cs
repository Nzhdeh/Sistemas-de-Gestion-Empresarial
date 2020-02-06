using ExamenSegundoTrimmestreAjaxBL.ListadosBL;
using ExamenSegundoTrimmestreAjaxET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ExamenSegundoTrimmestreAjaxUI.ApiControllers
{
    public class MisionesApiController : ApiController
    {
        /// <summary>
        /// sirve para obtener el listado de misiones de un superheroe en concreto
        /// </summary>
        /// <param name="idSuperheroe">id del superheroe</param>
        /// <returns>listado de misiones de un superheroes</returns>
        public List<ClsMision> Get(int idSuperheroe)
        {
            return new ClsListadoMisionesBL().misionesPorIdSuperheroeBL(idSuperheroe);
        }
    }
}