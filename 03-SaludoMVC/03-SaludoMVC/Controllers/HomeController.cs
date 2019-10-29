using _03_SaludoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_SaludoMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ClsPersona p = new ClsPersona();

            if(DateTime.Now.Hour>=8 && DateTime.Now.Hour<12)
            {
                ViewData["saludo"] = "Buenos dias";
            }
            else
            {
                if(DateTime.Now.Hour>=12 && DateTime.Now.Hour < 20) 
                {
                    ViewData["saludo"] = "Buenas tardes";
                }
                else 
                { 
                    if(DateTime.Now.Hour>=20 && DateTime.Now.Hour<8)
                    {
                        ViewData["saludo"] = "Buenas noches";
                    }
                }
            }

            p.Nombre = "Nzhdeh";
            p.Apellidos = "Yeghiazaryan";
            p.FechaNac = new DateTime(1991, 01, 16);

            

            return View(p);
        }
    }
}