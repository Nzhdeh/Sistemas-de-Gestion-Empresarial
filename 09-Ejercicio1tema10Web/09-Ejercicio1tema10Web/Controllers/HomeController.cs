using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace _09_Ejercicio1tema10Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

            //primera vez que entra
        public ActionResult Index()
        {
            return View();
        }

        //segunda vez
        [HttpPost,ActionName("Index")]
        public ActionResult IndexPost()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {
                miConexion.ConnectionString = "server=nzhdeh.database.windows.net;database=Personas;uid=nzhdeh;pwd=dnder.21;";
                miConexion.Open();
                ViewBag.Estado = miConexion.State;
            }
            catch (SqlException e)
            {
                return View("PaginaError");
            }
            return View();
        }
    }
}