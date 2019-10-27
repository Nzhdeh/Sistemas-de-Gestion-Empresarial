using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_ExamenSorpresaMVC.Models
{
    public class ClsPersonaConNombreDeDepartamento : ClsPersona
    {
        private String _nombre;

        public ClsPersonaConNombreDeDepartamento() : base()
        {
            this._nombre = "Nombre";
        }

        public ClsPersonaConNombreDeDepartamento(int id, String nombrePersona, String apellidos, int idDepartamento,string _nombre) : 
            base(id, nombrePersona,apellidos, idDepartamento)
        {
            this._nombre = _nombre;
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