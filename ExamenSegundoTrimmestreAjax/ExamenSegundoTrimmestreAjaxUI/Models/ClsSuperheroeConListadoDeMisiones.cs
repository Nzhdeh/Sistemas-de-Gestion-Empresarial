using ExamenSegundoTrimmestreAjaxBL.ListadosBL;
using ExamenSegundoTrimmestreAjaxET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSegundoTrimmestreAjaxUI.Models
{
    public class ClsSuperheroeConListadoDeMisiones : ClsSuperheroe
    {
        private List<ClsMision> listadoMisiones;

        public ClsSuperheroeConListadoDeMisiones()
        {
            listadoMisiones = new ClsListadoMisionesBL().misionesPorIdSuperheroeBL(IdSuperheroe);
        } 
        
        public List<ClsMision> ListadoMisiones { get; set; }
    }
}