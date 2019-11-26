using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _10_CRUDPersonaEntidadesWeb;
using _10_CRUDPersonaBLWeb.Listados;
using _10_CRUDPersonasWeb_UI.Models;
using _10_CRUDPersonaBLWeb.ServiciosPersonaBL;

namespace _10_CRUDPersonasWeb_UI.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Home

        //primera vez que entra
        public ActionResult List()
        {
            try
            {
                List<ClsPersona> personas;
                ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();
                personas = listadoPersonasBL.ListadoPersonas();
                List<ClsPersonaConNombreDeDepartamento> listaPersonaNombreDepartamento = new List<ClsPersonaConNombreDeDepartamento>();
                ClsGestoraDepartamentoBL gestoraDepartamentoBL = new ClsGestoraDepartamentoBL();

                for (int i = 0; i < personas.Count; i++)
                {
                    listaPersonaNombreDepartamento.Add(new ClsPersonaConNombreDeDepartamento(gestoraDepartamentoBL.BuscarDepartamentoPorId(personas[i].IdDepartamento).NombreDepartamento, personas[i]));
                }

                return View(listaPersonaNombreDepartamento);
            }
            catch(Exception e)
            {
                return View();
            }
        }


        //public ActionResult Create()
        //{
        //    ClsListadoDepartamentosBL capaBL = new ClsListadoDepartamentosBL();
        //    ClsPersonaConListadoDeDepartamentos personaListadoDpto = new ClsPersonaConListadoDeDepartamentos();
        //    personaListadoDpto.ListadoDepartamento = capaBL.ObtenerListadoDepartamentosBL();
        //    return View(personaListadoDpto);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "NombrePersona,ApellidosPersona,FechaNacimientoPersona,TelefonoPersona,IdDepartamento")] ClsPersona clsPersona)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        try
        //        {
        //            ClsGestoraPersonaBL listPersBL = new ClsGestoraPersonaBL();
        //            listPersBL.InsertarPersona(clsPersona);

        //            return RedirectToAction("List");
        //        }catch(SqlException e)
        //        {

        //        }

        //    //}

        //    return View(clsPersona);
        //}

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
                    i = gestoraPersonaBL.InsertarPersona(clsPersona);
                }
                catch (Exception)
                {

                    return View("PgnError");
                }

            }

            return RedirectToAction("List");
        }

        /// <summary>
        /// detalles de la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>objeto persona</returns>
        public ActionResult Details(int id)
        {
            //ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();
            //ClsGestoraDepartamentoBL gestoraDepartamentoBL = new ClsGestoraDepartamentoBL();
            //ClsPersona persona = new ClsPersona();
            //ClsDepartamento departamento = new ClsDepartamento();
            //persona = gestoraPersonaBL.BuscarPersonaPorId(id);
            //departamento = gestoraDepartamentoBL.BuscarDepartamentoPorId(persona.IdDepartamento);

            //ClsPersonaConNombreDeDepartamento personaConDpto = new ClsPersonaConNombreDeDepartamento();

            ////personaCompleta.idPersona = pers.idPersona;//no hace falta
            //personaConDpto.NombrePersona = persona.NombrePersona;
            //personaConDpto.ApellidosPersona = persona.ApellidosPersona;
            //personaConDpto.TelefonoPersona = persona.TelefonoPersona;
            //personaConDpto.FechaNacimientoPersona = persona.FechaNacimientoPersona;
            //personaConDpto.FotoPersona = persona.FotoPersona;
            //personaConDpto.NombreDepartamento = departamento.NombreDepartamento;

            //return View(personaConDpto);

            ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();
            ClsPersona persona = gestoraPersonaBL.BuscarPersonaPorId(id);

            return View(persona);
        }

        /// <summary>
        /// editar una persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ClsGestoraPersonaBL gestPersBL = new ClsGestoraPersonaBL();
            ClsPersonaConListadoDeDepartamentos personaListadoDpto = new ClsPersonaConListadoDeDepartamentos();
            ClsListadoDepartamentosBL listDeptBL = new ClsListadoDepartamentosBL();
            ClsPersona persona = gestPersBL.BuscarPersonaPorId(id);
            personaListadoDpto.ListadoDepartamento = listDeptBL.ObtenerListadoDepartamentosBL();

            personaListadoDpto.IdPersona = persona.IdPersona;
            personaListadoDpto.NombrePersona = persona.NombrePersona;
            personaListadoDpto.ApellidosPersona = persona.ApellidosPersona;
            personaListadoDpto.TelefonoPersona = persona.TelefonoPersona;
            personaListadoDpto.FechaNacimientoPersona = persona.FechaNacimientoPersona;           
            personaListadoDpto.FotoPersona = persona.FotoPersona;
            return View(personaListadoDpto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersona,NombrePersona,ApellidosPersona,FechaNacimientoPersona,TelefonoPersona,FotoPersona,IdDepartamento")] ClsPersona clsPersona)
        {
            if (ModelState.IsValid)
            {
                ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();
                gestoraPersonaBL.ActualizarPersona(clsPersona);
                
                return RedirectToAction("Index");
            }
            return View(clsPersona);
        }

        //public ActionResult Delete(int id)
        //{
        //    ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();
        //    ClsGestoraDepartamentoBL gestoraDepartamentoBL = new ClsGestoraDepartamentoBL();
        //    ClsPersona pers = new ClsPersona();
        //    ClsDepartamento dpto = new ClsDepartamento();
        //    pers = gestoraPersonaBL.BuscarPersonaPorId(id);
        //    dpto = gestoraDepartamentoBL.BuscarDepartamentoPorId(pers.IdDepartamento);

        //    ClsPersonaConNombreDeDepartamento personaCompleta = new ClsPersonaConNombreDeDepartamento();

        //    //personaCompleta.idPersona = pers.idPersona;//no hace falta
        //    personaCompleta.NombreDepartamento = pers.NombrePersona;
        //    personaCompleta.ApellidosPersona = pers.ApellidosPersona;
        //    personaCompleta.TelefonoPersona = pers.TelefonoPersona;
        //    personaCompleta.FechaNacimientoPersona = pers.FechaNacimientoPersona;            
        //    personaCompleta.FotoPersona = pers.FotoPersona;
        //    personaCompleta.NombreDepartamento = dpto.NombreDepartamento;

        //    return View(personaCompleta);
        //}


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();
        //    gestoraPersonaBL.BorrarPersonaPorId(id);
        //    return RedirectToAction("List");
        //}

        public ActionResult Delete(int id)
        {
            ClsGestoraPersonaBL gestoraPersonaBL = new ClsGestoraPersonaBL();
            ClsPersona persona = gestoraPersonaBL.EditarPersona(id);

            return View(persona);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
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
                    i = gestoraPersonaBL.BorrarPersonaPorId(id);
                }
                catch (Exception)
                {

                    return View("PgnError");
                }

            }

            return RedirectToAction("List");
        }
    }
}