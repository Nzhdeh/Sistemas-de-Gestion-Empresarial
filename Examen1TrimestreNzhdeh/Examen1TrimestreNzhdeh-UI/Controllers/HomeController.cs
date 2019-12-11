using Examen1TrimestreNzhdeh_ET;
using Examen1TrimestreNzhdeh_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//DADA FUNCIONA
namespace Examen1TrimestreNzhdeh_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ClsIndexVM viewModel = new ClsIndexVM();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ClsIndexVM viewModel,ClsSuperheroe superheroeSeleccionado)
        {
            viewModel = new ClsIndexVM(viewModel.ListadoVengadores,superheroeSeleccionado);

            //me estoy liando más y más

            return View(viewModel);
        }
    }
}