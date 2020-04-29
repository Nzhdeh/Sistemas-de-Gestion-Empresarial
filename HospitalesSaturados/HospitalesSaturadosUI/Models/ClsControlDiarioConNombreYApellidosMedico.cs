using HospitalesSaturadosET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalesSaturadosUI.Models
{
    public class ClsControlDiarioConNombreYApellidosMedico : ClsControlDiario
    {
        private string nombreMedico;
        private string apellidosMedico;

        public ClsControlDiarioConNombreYApellidosMedico() : base()
        {
            this.nombreMedico = "";
            this.apellidosMedico = "";
        }
        public ClsControlDiarioConNombreYApellidosMedico(string nombreMedico, string apellidosMedico, ClsControlDiario control) : 
            base(control.CodigoMedico,control.Fecha,control.PrimeraSesion,control.SegundaSesion,control.TerceraSesion,control.CuartaSesion)
        {
            this.nombreMedico = nombreMedico;
            this.apellidosMedico = apellidosMedico;
        }

        //se usa solo si el médico no tiene control diario
        public ClsControlDiarioConNombreYApellidosMedico(string nombreMedico, string apellidosMedico)
        {
            this.nombreMedico = nombreMedico;
            this.apellidosMedico = apellidosMedico;
        }


        public string NombreMedico
        {
            get
            {
                return this.nombreMedico;
            }
            set
            {
                this.nombreMedico = value;
            }
        }

        public string ApellidosMedico
        {
            get
            {
                return this.apellidosMedico;
            }
            set
            {
                this.apellidosMedico = value;
            }
        }
    }
}