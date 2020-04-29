﻿using HospitalesSaturadosBL.ManejadorasBL;
using HospitalesSaturadosUI.Utilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace HospitalesSaturadosUI.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// este metodo sirve para calcular el diagnostico
        /// </summary>
        /// <param name="frm"> recibe un FormCollection el cual contiene las respuestas del usuario</param>
        /// <returns></returns>
        public ActionResult Entrar(System.Web.Mvc.FormCollection frm)
        {
            string codigoMedico = "";
            bool error = false;//esto sirve para evitar poner mas returns

            try
            {
                codigoMedico = frm[0].ToString();//obtengo el codigo del medico

                if (new ClsUtil().IsCodigoMedicoValido(codigoMedico) && !new ClsGestionMedicoBL().ExisteMedicoBL(codigoMedico))
                {
                    ViewBag.MensajeError = "El médico no existe";
                    error = true;
                }
                else if(!new ClsUtil().IsCodigoMedicoValido(codigoMedico))
                {
                    ViewBag.MensajeError = "El código no es válido";
                    error = true;
                }
                if (error)
                {
                    return View("Index");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return RedirectToAction("Detalle", "Detalle", new { codigo = codigoMedico });
        }
    }
}