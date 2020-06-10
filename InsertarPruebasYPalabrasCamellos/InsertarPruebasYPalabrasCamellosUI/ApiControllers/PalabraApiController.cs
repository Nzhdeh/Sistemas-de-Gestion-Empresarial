using InsertarPruebasYPalabrasCamellosBL.ListadosBL;
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
    public class PalabraApiController : ApiController
    {
        // GET: api/PalabraApi
        //[Route("{n:int}")]
        //sirve para obtener el listado de ids de las últimas N palabras introducidas
        public List<int> Get(int numero)
        {
            List<int> lista = new List<int>();
            try
            {
                lista = new ClsListadoUltimasNPalabrasBL().ObtenerIdsDeUltimasNPalabrasBL(numero);
            }
            catch (Exception e)
            {
                new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Hubo algún problema, inténtalo más tarde") };
            }
            
            return lista;
        }

        //// GET: api/PalabraApi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: sirve para guardar un objeto ClsPalabra en la bbdd
        public HttpResponseMessage Post([FromBody]ClsPalabras palabra)
        {
            HttpResponseMessage http = new HttpResponseMessage();
            int resultado = 0;
            try
            {
                resultado = new ClsManejadoraPalabraBL().InsertarPalabraBL(palabra);

                if (resultado != 0)
                {
                    http = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("Insertado correctamente")
                    };
                }
                else
                {
                    http = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("No se ha insertado")
                    };
                }
            }
            catch (Exception e)
            {
                http = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Hubo algún problema, inténtalo más tarde") };
            }
            return http;
        }

        // PUT: api/PalabraApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/PalabraApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
