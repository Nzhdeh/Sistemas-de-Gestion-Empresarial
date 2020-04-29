using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CuestionarioCoronavirusET
{
    public class ClsPersona
    {
        private string dniPersona;
        private string nombrePersona;
        private string apellidosPerson;
        private string telefono;
        private string direccion;
        private bool diagnostico;


        public ClsPersona()
        {
            this.dniPersona = "";
            this.nombrePersona = "";
            this.apellidosPerson = "";
            this.telefono = "";
            this.direccion = "";
            this.diagnostico = false;
        }

        public ClsPersona(string dniPersona, string nombrePersona, string apellidosPerson, string telefono, string direccion, bool diagnostico)
        {
            this.dniPersona = dniPersona;
            this.nombrePersona = nombrePersona;
            this.apellidosPerson = apellidosPerson;
            this.telefono = telefono;
            this.direccion = direccion;
            this.diagnostico = diagnostico;
        }

        public ClsPersona(bool diagnostico)
        {
            this.dniPersona = "";
            this.nombrePersona = "";
            this.apellidosPerson = "";
            this.telefono = "";
            this.direccion = "";
            this.diagnostico = diagnostico;
        }

        [Key]
        [Display(Name = "DNI: ")]
        //[Required(ErrorMessage = "El dni es obligatorio.")]
        public string DniPersona
        {
            get
            {
                return dniPersona;
            }
            set
            {
                dniPersona = value;
            }
        }

        [Display(Name = "Nombre: ")]
        //[Required(ErrorMessage = "El nombre es obligatorio.")]
        public string NombrePersona
        {
            get
            {
                return nombrePersona;
            }
            set
            {
                nombrePersona = value;
            }
        }

        [Display(Name = "Apellidos: ")]
        //[Required(ErrorMessage = "Los apellidos son obligatorios.")]
        public string ApellidosPerson
        {
            get
            {
                return apellidosPerson;
            }
            set
            {
                apellidosPerson = value;
            }
        }

        [Display(Name = "Teléfono: ")]
        //[Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }

        [Display(Name = "Dirección: ")]
        //[Required(ErrorMessage = "La dirección es obligatorio.")]
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        [Display(Name = "Diagnóstrico: ")]
        //[Required(ErrorMessage = "El diagnóstico es obligatorio.")]
        public bool Diagnostico
        {
            get
            {
                return diagnostico;
            }
            set
            {
                diagnostico = value;
            }
        }
    }
}
