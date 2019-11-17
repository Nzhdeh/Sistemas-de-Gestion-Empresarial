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


        public ActionResult Create()
        {
            return View();//aqui no hay try
        }

        [HttpPost]
        public ActionResult Create(ClsPersona persona)
        {
            if (ModelState.IsValid)
            {
                try
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
                            i = gestoraPersonaBL.InsertarPersona(persona);
                        }
                        catch (Exception)
                        {

                            return View("Error");//crear pagina de error
                        }

                    }

                    return RedirectToAction("List");
                    //return View();//esta vista tiene que mostrar un mensaje de guardado cvorrectamente
                }
                catch(Exception e)
                {
                    return View(/*Error*/);
                }
            }
            else
            {
                return View();
            }
        }
    }
}