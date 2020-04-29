using HospitalesSaturadosBL.ManejadorasBL;
using HospitalesSaturadosET;
using HospitalesSaturadosUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace HospitalesSaturadosUI.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Detalle
        /// <summary>
        /// seirve para obtener al médico y sus tareas para lostrarlos en la vista
        /// </summary>
        /// <param name="file">código del medico introdicido</param>
        /// <returns></returns>
        public ActionResult Detalle(string file)//file es el codigo del medico introducido
        {
            ClsMedico oMedico = new ClsMedico();
            ClsControlDiario oControl = new ClsControlDiario();
            ClsControlDiarioConNombreYApellidosMedico oDetalle = new ClsControlDiarioConNombreYApellidosMedico();

            try
            {
                if (!String.IsNullOrEmpty(file))
                {
                    oMedico = new ClsGestionMedicoBL().ObtenerMedicoBL(file);
                    oControl = new ClsGestionTareasBL().TareasPorCodigoMedicoYFechaDeHoyDAL(file);
                    if (oControl != null)
                    {
                        oDetalle = new ClsControlDiarioConNombreYApellidosMedico(oMedico.NombreMedico, oMedico.ApellidosMedico, oControl);
                    }
                    else
                    {
                        ViewBag.Codigo = "Hoy no tiene tareas";
                        oDetalle = new ClsControlDiarioConNombreYApellidosMedico(oMedico.NombreMedico, oMedico.ApellidosMedico);//solo si no tiene tareas
                    }
                }
                else
                {
                    return View("PgnError");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(oDetalle);
        }

        /// <summary>
        /// se va a la pagina inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Volver()
        {
            return RedirectToAction("Index", "Index");
        }
    }
}