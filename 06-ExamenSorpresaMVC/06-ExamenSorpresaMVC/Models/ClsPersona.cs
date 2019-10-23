using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_ExamenSorpresaMVC.Models
{
    public class ClsPersona
    {
        private int _id;
        private String _nombre;
        private String _apellidos;
        private int _idDepartamento;

        public ClsPersona() 
        {
            this._id = 0;
            this._nombre = "Nombre";
            this._apellidos = "Apellidos";
            this._idDepartamento = 0;
        }

        public ClsPersona(int _id,String _nombre,String _apellidos,int _idDepartamento)
        {
            this._id = _id;
            this._nombre = _nombre;
            this._apellidos = _apellidos;
            this._idDepartamento = _idDepartamento;
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

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }

        public int IdDepartamento
        {
            get
            {
                return _idDepartamento;
            }
        }
    }
}