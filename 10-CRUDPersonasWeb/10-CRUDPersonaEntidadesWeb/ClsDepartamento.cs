﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _10_CRUDPersonaEntidadesWeb
{
    public class ClsDepartamento
    {
        public ClsDepartamento()
        {
            this.IdDepartamentoa = 0;
            this.NombreDepartamento = "No nombre";
        }

        public int IdDepartamentoa { get; set; }
        public String NombreDepartamento { get; set; }
    }
}