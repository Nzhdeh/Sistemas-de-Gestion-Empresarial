using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _10_CRUDPersonaEntidadesWeb;

namespace _10_CRUDPersonasWeb_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        //primera vez que entra
        public ActionResult List()
        {
            try
            {
                return View(/*la lista de personas*/);
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
                    //TODO insertar en la bbdd
                    return View();//esta vista tiene que mostrar un mensaje de guardado cvorrectamente
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