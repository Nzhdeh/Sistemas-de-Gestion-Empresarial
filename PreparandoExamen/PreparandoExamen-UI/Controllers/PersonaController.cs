using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PreparandoExamen_ENTITIES;
using PreparandoExamen_BL.ListadosBL;
using PreparandoExamen_BL.ServiciosBL;

namespace PreparandoExamen_UI.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Home

        //primera vez que entra
        public ActionResult Index()
        {
            try
            {
                List<ClsPersona> personas;
                ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();
                personas = listadoPersonasBL.ObtenerListadoPersonasBL();

                return View(personas);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// detalles de la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objeto persona</returns>
        public ActionResult Details(int id)
        {
            ClsGestoraPersonaBL gp = new ClsGestoraPersonaBL();
            ClsPersona persona = gp.BuscarPersonaPorIdBL(id);

            return View(persona);
        }

        public ActionResult Delete(int id)
        {
            ClsGestoraPersonaBL gp = new ClsGestoraPersonaBL();
            ClsPersona persona = gp.BuscarPersonaPorIdBL(id);

            return View(persona);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            int i = 0;

            ClsGestoraPersonaBL gp = new ClsGestoraPersonaBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    i = gp.BorrarPersonaPorIdBL(id);
                }
                catch (Exception)
                {

                    return View("Error");
                }

            }

            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClsPersona clsPersona)
        {
            int i = 0;

            ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    i = gestoraPersonaBL.InsertarPersonaBL(clsPersona);
                }
                catch (Exception)
                {

                    return View("Error");
                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ClsGestoraPersonaBL gp = new ClsGestoraPersonaBL();
            //ClsPersonaListadoDepartamento personaListadoDepartamento;
            //List<clsDepartamento> departamentos;
            //clsListadoDepartamentosBL listadoDepartamentosBL = new clsListadoDepartamentosBL();
            //departamentos = listadoDepartamentosBL.getListadoDepartamentosBL();
            ClsPersona persona = gp.BuscarPersonaPorIdBL(id);


            return View(persona);
        }

        [HttpPost]
        public ActionResult Edit(ClsPersona persona)
        {
            int i = 0;

            ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();

            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            else
            {
                i = gestoraPersonaBL.ActualizarPersonaBL(persona);
            }

            return RedirectToAction("Index");
        }

    }
}