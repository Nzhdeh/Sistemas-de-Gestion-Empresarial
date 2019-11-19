using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSorpresaCRUD_Entities
{
    public class ClsDepartamento
    {
        public ClsDepartamento()
        {
            this.IdDepartamentoa = 0;
            this.NombreDepartamento = "por defecto";
        }

        public int IdDepartamentoa { get; set; }
        public String NombreDepartamento { get; set; }
    }
}