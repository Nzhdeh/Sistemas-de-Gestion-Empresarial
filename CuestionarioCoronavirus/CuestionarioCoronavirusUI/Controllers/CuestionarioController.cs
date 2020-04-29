using CuestionarioCoronavirusBL.ListadosBL;
using CuestionarioCoronavirusBL.ManejadorasBL;
using CuestionarioCoronavirusET;
using CuestionarioCoronavirusUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuestionarioCoronavirusUI.Controllers
{
    public class CuestionarioController : Controller
    {
        // GET: Cuestionario
        public ActionResult List()
        {
            ObservableCollection<ClsPreguntaConListadoRespuestas> preguntaConListadoRespuestas = null;
            try
            {
                preguntaConListadoRespuestas = new ObservableCollection<ClsPreguntaConListadoRespuestas>();
                ObservableCollection<ClsPregunta> listado = new ClsListadoPreguntasBL().ListadoPreguntasBL();
                ClsPreguntaConListadoRespuestas p = null;

                for (int i = 0; i < listado.Count; i++)
                {
                    p = new ClsPreguntaConListadoRespuestas();
                    p.Pregunta = listado[i].Pregunta;
                    p.IdPregunta = listado[i].IdPregunta;
                    p.ListadoRespuestasPorPregunta = new ClsListadoRespuestasBL().ListadoRespuestasPorPreguntaBL(p.IdPregunta);
                    preguntaConListadoRespuestas.Add(p);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            
            return View(preguntaConListadoRespuestas);
        }

        /// <summary>
        /// este metodo sirve para calcular el diagnostico
        /// </summary>
        /// <param name="frm"> recibe un FormCollection el cual contiene las respuestas del usuario</param>
        /// <returns></returns>
        public ActionResult Siguiente(FormCollection frm)
        {
            int contadorTrues = 0;
            bool diagnostico = false;
            bool DisplayFiles = false;

            try
            {
                ObservableCollection<ClsPregunta> listado = new ClsListadoPreguntasBL().ListadoPreguntasBL();//hace falta para calcular el 70 porcien
               
                List<string> res = new List<string>();

                for (int i = 0; i < listado.Count; i++)
                {
                    res.Add(frm[i].ToString());
                }

                for (int i = 0; i < res.Count; i++)
                {
                    if (res[i] == "Si")
                    {
                        contadorTrues++;
                    }
                }

                if (contadorTrues > listado.Count * 0.7)
                {
                    diagnostico = true;
                }

                DisplayFiles = diagnostico;
            }
            catch(Exception)
            {
                return View("Error");
            }
           
            
            return RedirectToAction("Create", "Diagnostico", new { file = DisplayFiles });
        }
    }
}