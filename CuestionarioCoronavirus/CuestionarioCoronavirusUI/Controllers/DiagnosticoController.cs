using CuestionarioCoronavirusBL.ManejadorasBL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuestionarioCoronavirusUI.Controllers
{
    public class DiagnosticoController : Controller
    {
        // GET: Diagnostico
        public ActionResult Create(string file)//file es el diagnostico calculado
        {
            if (!String.IsNullOrEmpty(file))
            {
                ViewBag.Diagnostico = file;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClsPersona clsPersona)
        {
            ClsGestionPersonaBL gestoraPersonaBL = new ClsGestionPersonaBL();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            else
            {
                try
                {
                    gestoraPersonaBL.InsertarPersonaBL(clsPersona);
                }
                catch (Exception)
                {
                    return View("PgnError");
                }

            }
            //return RedirectToAction(nameof(IndexController.Index),"Index");//tenia puesto que se fuera a la pagina inicial,pero lo cambié
            return View("Exito");
        }
    }
}