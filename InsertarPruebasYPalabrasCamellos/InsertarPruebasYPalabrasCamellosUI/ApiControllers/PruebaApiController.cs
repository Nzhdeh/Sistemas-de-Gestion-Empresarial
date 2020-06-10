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
    public class PruebaApiController : ApiController
    {
        // GET: api/PruebaApi
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: sirve para obtener el id de la última prueba insertada
        public int Get()
        {
            var id = 0;
            try
            {
                id = new ClsManejadoraPruebaBL().ObtenerIdUltimaPruebaBL();
            }
            catch (Exception e)
            {
                new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Hubo algún problema, inténtalo más tarde") };
            }
            return id;
        }

        // POST: sirve para guardar una prueba
        public HttpResponseMessage Post([FromBody]ClsPrueba prueba)
        {
            HttpResponseMessage http = new HttpResponseMessage();
            int resultado = 0;
            try
            {
                resultado = new ClsManejadoraPruebaBL().InsertarPruebaBL(prueba);

                if (resultado != 0)
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

        // PUT: api/PruebaApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/PruebaApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
