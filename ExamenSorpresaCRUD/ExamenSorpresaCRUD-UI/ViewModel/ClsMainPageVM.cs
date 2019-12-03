using ExamenSorpresaCRUD_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSorpresaCRUD_UI.ViewModel
{
    public class ClsMainPageVM
    {
        private List<ClsDepartamento> listadoDepartamentos;
        private ClsDepartamento departamentoSeleccionado;
        private List<String> listadoApellidosPersonaPorIdDepartamento;
        private ClsPersona personaSeleccionada;

        public ClsMainPageVM()
        {
            this.listadoDepartamentos=null;
            this.departamentoSeleccionado=new ClsDepartamento();
            this.listadoApellidosPersonaPorIdDepartamento=null;
            this.personaSeleccionada=new ClsPersona();
        }

        public ClsMainPageVM(List<ClsDepartamento> listadoDepartamentos,ClsDepartamento departamentoSeleccionado,List<String> listadoApellidosPersonaPorIdDepartamento,ClsPersona personaSeleccionada)
        {
            this.listadoDepartamentos = listadoDepartamentos;
            this.departamentoSeleccionado = departamentoSeleccionado;
            this.listadoApellidosPersonaPorIdDepartamento = listadoApellidosPersonaPorIdDepartamento;
            this.personaSeleccionada = personaSeleccionada;
        }

        public List<ClsDepartamento> ListadoDepartamentos { get; set; }

        public ClsDepartamento DepartamentoSeleccionado { get; set; }

        public List<String> ListadoApellidosPersonaPorIdDepartamento { get; set; }

        public ClsPersona PersonaSeleccionada { get; set; }
    }
}