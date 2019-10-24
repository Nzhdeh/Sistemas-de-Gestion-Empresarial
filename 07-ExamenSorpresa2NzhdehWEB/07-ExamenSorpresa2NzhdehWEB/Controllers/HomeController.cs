using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_ExamenSorpresa2NzhdehWEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(bool? esMiPrimeraVez)
        {
            if (esMiPrimeraVez==true) 
            {
                ViewBag.Text = "No es tu primera vez";
            }
            else 
            {
                ViewBag.Text = "Es tu primera vez";
            }

            return View();
        }
    }
}