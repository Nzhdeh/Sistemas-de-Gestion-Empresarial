using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_ExamenSorpresaMVC.Models
{
    public class ClsDepartamento
    {
        private int _id;
        private String _nombre;

        public ClsDepartamento()
        {
            this._id = 0;
            this._nombre = "Nombre";
        }

        public ClsDepartamento(int id, string nombre)
        {
            this._id = id;
            this._nombre = nombre;
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nombre
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