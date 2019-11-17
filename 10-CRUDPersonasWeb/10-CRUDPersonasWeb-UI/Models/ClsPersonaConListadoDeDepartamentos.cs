﻿using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _10_CRUDPersonasWeb_UI.Models
{
    public class ClsPersonaConListadoDeDepartamentos : ClsPersona
    {
        public List<ClsDepartamento> ListadoDepartamento { get; set; }

        public ClsPersonaConListadoDeDepartamentos() : base()
        {
            this.ListadoDepartamento = new List<ClsDepartamento>();
        }

        public ClsPersonaConListadoDeDepartamentos(List<ClsDepartamento> listadoDepartamento, ClsPersona persona) : base()
        {
            this.ListadoDepartamento = listadoDepartamento;
        }
    }
}