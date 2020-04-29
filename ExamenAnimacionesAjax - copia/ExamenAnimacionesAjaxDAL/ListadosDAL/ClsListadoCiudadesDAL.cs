using ExamenAnimacionesAjaxDAL.Conexion;
using ExamenAnimacionesAjaxET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesAjaxDAL.ListadosDAL
{
    public class ClsListadoCiudadesDAL
    {
        /// <summary>
        /// esta funcion sirve para obtener el listado de todas las ciudades de la API
        /// </summary>
        /// <returns>Listado de ciudades ObservableCollection<ClsCiudad></returns>
        public async Task<ObservableCollection<ClsCiudad>> listadoCiudadesDAL()
        {
            ObservableCollection<ClsCiudad> listado = new ObservableCollection<ClsCiudad>();
            HttpClient miCliente = new HttpClient();

            Uri requestUri = new Uri(ClsMyConnection.getUriBase()+"ciudades");

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                httpResponse = await miCliente.GetAsync(requestUri);

                if (httpResponse.IsSuccessStatusCode)
                {
                    httpResponseBody = await miCliente.GetStringAsync(requestUri);
                    listado = JsonConvert.DeserializeObject<ObservableCollection<ClsCiudad>>(httpResponseBody);
                }


            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listado;

        }
    }
}
