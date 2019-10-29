using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _07_ExamenSorpresa2NzhdehWEB.Models
{
    public class ClsPersona
    {
        private int id;
        private String nombre;
        private String apellidos;
        private DateTime frchanacimiento;
        private String telefono;
        private String direccion;

        public ClsPersona()
        {
            this.id = 0;
            this.nombre="nzhdeh";
            this.apellidos="Yeghiazaryan";
            this.frchanacimiento=new DateTime();
            this.telefono="666666666";
            this.direccion="mi direccion";
        }

        public ClsPersona(int id, String nombre,String apellidos,DateTime frchanacimiento,String telefono,String direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.frchanacimiento = frchanacimiento;
            this.telefono = telefono;
            this.direccion = direccion;
        }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]//ocultar
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]//campo obligatorio
        public string Nombre { get; set; }

        [MaxLength(39), Required]//campo obligatorio y menor que 40 caracteres
        public string Apellidos { get; set; }

        [DataType(DataType.Date)]//especifica el tipo de la propiedad
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]//fecha en formato corto
        public DateTime FechaNacimiento { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; }
    }
}