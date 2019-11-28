using _11_CRUDPersonaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _11_CRUDPersonasWeb_UI.Models
{
    public class ClsPersonaConNombreDeDepartamento : ClsPersona
    {
        public ClsPersonaConNombreDeDepartamento() : base()
        {
            NombreDepartamento = "default";
        }

        public ClsPersonaConNombreDeDepartamento(String departamento, ClsPersona persona) : 
            base(persona.IdPersona,persona.NombrePersona,persona.ApellidosPersona,persona.FechaNacimientoPersona,
                persona.TelefonoPersona,persona.IdDepartamento)
        {
            this.NombreDepartamento = departamento;
        }

        public String NombreDepartamento { get; set; }
    }
}