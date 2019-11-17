using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _10_CRUDPersonasWeb_UI.Models
{
    public class ClsPersonaConNombreDeDepartamento : ClsPersona
    {
        public String nombreDepartamento { get; set; }

        public ClsPersonaConNombreDeDepartamento() : base()
        {
            nombreDepartamento = "default";
        }

        public ClsPersonaConNombreDeDepartamento(String departamento, ClsPersona persona) : base()
        {
            this.nombreDepartamento = departamento;
        }
    }
}