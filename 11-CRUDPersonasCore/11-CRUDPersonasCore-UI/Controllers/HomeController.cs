using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _11_CRUDPersonasCore_UI.Models;
using _11_CRUDPersonaEntities;
using _11_CRUDPersonaBL.Listas;
using _11_CRUDPersonasWeb_UI.Models;
using _11_CRUDPersonaBL.Manejadoras;

namespace _11_CRUDPersonasCore_UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
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
            catch (Exception e)
            {
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
