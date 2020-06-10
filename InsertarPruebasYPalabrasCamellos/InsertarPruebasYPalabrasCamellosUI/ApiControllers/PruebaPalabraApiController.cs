using InsertarPruebasYPalabrasCamellosBL.ManejadorasBL;
using InsertarPruebasYPalabrasCamellosET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsertarPruebasYPalabrasCamellosUI.Controllers
{
    public class PruebaPalabraApiController : ApiController
    {
        // GET: api/PruebaPalabraApi
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/PruebaPalabraApi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: sirve para hacer corresponder las palabras con una prueba
        public HttpResponseMessage Post([FromBody]ClsPruebaPalabra pruebaPalabra)
        {
            HttpResponseMessage http = new HttpResponseMessage();
            int res = 0;
            try
            {
                res = new ClsManejadoraPruebaPalabraBL().InsertarPruebaPalabrasDAL(pruebaPalabra.IdPrueba, pruebaPalabra.IdPalabra);

                if (res != 0)
                {
                    http = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Insertado correctamente") };
                }
                else
                {
                    http = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("No se ha insertado") };
                }
            }
            catch (Exception e)
            {
                http = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Hubo algún problema, inténtalo más tarde") };
            }
            
            return http;
        }

        // PUT: api/PruebaPalabraApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/PruebaPalabraApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
