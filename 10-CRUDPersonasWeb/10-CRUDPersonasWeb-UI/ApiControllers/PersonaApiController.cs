using _10_CRUDPersonaBLWeb.Listados;
using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _10_CRUDPersonasWeb_UI.ApiControllers
{
    public class PersonaApiController : ApiController
    {
        // GET: api/PersonaApi
        public IEnumerable<ClsPersona> Get()
        {
            return new ClsListadoPersonasBL().ListadoPersonas();
        }

        // GET: api/PersonaApi/5
        public ClsPersona Get(int id)
        {
            return null;//new ClsListadoPersonasBL().ObtenerPersonaPorId(id);
        }

        // POST: api/PersonaApi
        public void Post([FromBody]ClsPersona value)
        {
            //new ClsListadoPersonasBL().InsertarPersona(value);
        }

        // PUT: api/PersonaApi/5
        public void Put(int id, [FromBody]ClsPersona value)
        {
            //new ClsListadoPersonasBL().ActualizarPersona(value);
        }

        // DELETE: api/PersonaApi/5
        public void Delete(int id)
        {
            //new ClsListadoPersonasBL().DeletePersona(id);
        }
    }
}
