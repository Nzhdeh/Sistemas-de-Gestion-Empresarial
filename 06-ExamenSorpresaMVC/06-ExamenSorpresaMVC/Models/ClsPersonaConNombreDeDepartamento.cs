using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_ExamenSorpresaMVC.Models
{
    public class ClsPersonaConNombreDeDepartamento : ClsPersona
    {
        private String _nombre;

        public ClsPersonaConNombreDeDepartamento()
        {
            this._nombre = "Nombre";
        }

        public ClsPersonaConNombreDeDepartamento(string nombre)
        {
            this._nombre = nombre;
        }

        public string NombreDepartamento
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
    }
}