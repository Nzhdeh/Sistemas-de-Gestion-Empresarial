using ExamenSorpresaCRUD2_BL.Listas;
using ExamenSorpresaCRUD2_ET;
using ExamenSorpresaCRUD2_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenSorpresaCRUD2_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ClsListadosDepartamentosBL capaBL = new ClsListadosDepartamentosBL();
            ClsListadoDepartamentosListadosPersonas list = new ClsListadoDepartamentosListadosPersonas();
            list.Dptos = capaBL.listadoDepartamentos();
            list.Personas = new List<ClsPersona>();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string btnSeleccionar, string btnDetalles, ClsListadoDepartamentosListadosPersonas list)
        {
            ClsListadoDepartamentosListadosPersonas listado = new ClsListadoDepartamentosListadosPersonas();
            ClsListadosPersonaBL capaBL = new ClsListadosPersonaBL();
            ClsListadosDepartamentosBL capaBLDpto = new ClsListadosDepartamentosBL();
            if (btnSeleccionar != null)
            {
                listado.Dptos = capaBLDpto.listadoDepartamentos();
                listado.Personas = capaBL.personasPorIDDepartamento(list.DepartamentoSeleccionado.ID);
                return View(listado);
            }
            else
            {
                listado.Dptos = capaBLDpto.listadoDepartamentos();
                listado.Personas = capaBL.personasPorIDDepartamento(list.DepartamentoSeleccionado.ID);
                listado.PersonaSeleccionada = capaBL.personaPorID(list.PersonaSeleccionada.IDPersona);
                //Detalles
                return View(listado);
            }
        }
    }
}