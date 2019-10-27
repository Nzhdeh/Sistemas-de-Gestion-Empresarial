using _06_ExamenSorpresaMVC.Models;
using _06_ExamenSorpresaMVC.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_ExamenSorpresaMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            ClsPersonaConListadoDeDepartamentos personaConListaDep = new ClsPersonaConListadoDeDepartamentos();
            ClsPersona p = new ClsPersona(1,"Nzhdeh", "Yeghiazaryan", 1);
            List<ClsDepartamento> d = GestionDepartamentos.listaDepartamentos();

            personaConListaDep.Nombre = p.Nombre;
            personaConListaDep.Apellidos = p.Apellidos;
            personaConListaDep.IdDepartamento = p.IdDepartamento;
            personaConListaDep.ListadoDepartamentos = d;


            return View(personaConListaDep);
        }

        [HttpPost]
        public ActionResult Index(ClsPersonaConListadoDeDepartamentos persona)
        {
            GestionDepartamentos gd = new GestionDepartamentos();
            ClsPersonaConNombreDeDepartamento personaNueva = new ClsPersonaConNombreDeDepartamento();
            personaNueva.Nombre = persona.Nombre;
            personaNueva.Apellidos = persona.Apellidos;
            personaNueva.NombreDepartamento = gd.nombreDepartamentoPorID(persona.IdDepartamento);
            // persona.nombreDepartamento = dpto;
            return View("Persona", personaNueva);
        }
    }
}
