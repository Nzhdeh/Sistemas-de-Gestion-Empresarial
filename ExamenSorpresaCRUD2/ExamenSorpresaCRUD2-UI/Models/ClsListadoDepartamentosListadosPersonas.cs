using ExamenSorpresaCRUD2_BL.Listas;
using ExamenSorpresaCRUD2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSorpresaCRUD2_UI.Models
{
    public class ClsListadoDepartamentosListadosPersonas
    {
        private ClsListadosDepartamentosBL capaBL = new ClsListadosDepartamentosBL();
        public ClsListadoDepartamentosListadosPersonas()
        {

        }

        public ClsListadoDepartamentosListadosPersonas(List<ClsDepartamento> dptos, List<ClsPersona> personas, ClsDepartamento dpto, ClsPersona persona)
        {
            Dptos = dptos;
            Personas = personas;
            DepartamentoSeleccionado = dpto;
            PersonaSeleccionada = persona;
        }
        public List<ClsDepartamento> Dptos { get; set; }
        public List<ClsPersona> Personas { get; set; }

        public ClsDepartamento DepartamentoSeleccionado { get; set; }
        public ClsPersona PersonaSeleccionada { get; set; }
    }
}