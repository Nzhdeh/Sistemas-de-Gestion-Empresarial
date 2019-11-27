using _10_CRUDPersonaBLWeb.Listados;
using _10_CRUDPersonaBLWeb.ServiciosPersonaBL;
using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _10_CRUDPersonasWeb_UI.ApiControllers
{
    public class DepartamentoApiController : ApiController
    {
        // GET: api/DepartamentoApi
        public IEnumerable<ClsDepartamento> Get()
        {
            return new ClsListadoDepartamentosBL().ObtenerListadoDepartamentosBL();
        }

        // GET: api/DepartamentoApi/5
        public ClsDepartamento Get(int id)
        {
            return new ClsGestoraDepartamentoBL().BuscarDepartamentoPorId(id);
        }

        //// POST: api/DepartamentoApi
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/DepartamentoApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/DepartamentoApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
