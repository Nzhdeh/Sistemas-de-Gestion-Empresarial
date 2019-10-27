using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_ExamenSorpresaMVC.Models
{
    public class ClsPersonaConListadoDeDepartamentos : ClsPersona
    {
        public List<ClsDepartamento> ListadoDepartamentos { get; set; }
    }
}