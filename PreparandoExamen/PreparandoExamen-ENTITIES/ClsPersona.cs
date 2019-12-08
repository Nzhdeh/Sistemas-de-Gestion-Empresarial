using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PreparandoExamen_ENTITIES
{
    public class ClsPersona
    {
        #region constructores
        public ClsPersona()
        {
            IdPersona = 0;
            NombrePersona = "";
            ApellidosPersona = "";
            FechaNacimientoPersona = new DateTime();
            IdDepartamento = 0;
            TelefonoPersona = "";
        }

        public ClsPersona(string nombre, string apellidos, int id, DateTime fechaNac, int idDepartamento, string telefono)
        {
            this.IdPersona = id;
            this.NombrePersona = nombre;
            this.ApellidosPersona = apellidos;
            this.FechaNacimientoPersona = fechaNac;
            this.IdDepartamento = idDepartamento;
            this.TelefonoPersona = telefono;
        }
        #endregion

        #region propiedades publicas

        [Display(Name = "ID")]
        public int IdPersona { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombrePersona { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string ApellidosPersona { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimientoPersona { get; set; }
        [Display(Name = "IdDepartamento")]
        public int IdDepartamento { get; set; }
        [Display(Name = "Teléfono")]
        public string TelefonoPersona { get; set; }
        #endregion
    }
}