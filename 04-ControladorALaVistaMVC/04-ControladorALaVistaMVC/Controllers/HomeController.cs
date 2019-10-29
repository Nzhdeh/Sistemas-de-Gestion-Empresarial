using _03_SaludoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_ControladorALaVistaMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPersonas()
        {
            List<ClsPersona> lista = new List<ClsPersona>();

            DateTime f1 = new DateTime(1991,1,16);
            DateTime f2 = new DateTime(2000,10,25);
            DateTime f3 = new DateTime(1999,5,5);

            lista.Add(new ClsPersona(1, "Nzhdeh", "Yeghiazaryan", f1));
            lista.Add(new ClsPersona(1, "Yeray", "Capiyeri", f2));
            lista.Add(new ClsPersona(1, "Rafa", "Compadre", f3));

            return View(lista);
        }
    }
}