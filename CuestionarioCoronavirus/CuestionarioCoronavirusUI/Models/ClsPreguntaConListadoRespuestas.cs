using CuestionarioCoronavirusBL.ListadosBL;
using CuestionarioCoronavirusBL.ManejadorasBL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace CuestionarioCoronavirusUI.Models
{
    public class ClsPreguntaConListadoRespuestas : ClsPregunta
    {
        private ObservableCollection<ClsRespuesta> listadoRespuestasPorPregunta;

        public ClsPreguntaConListadoRespuestas() : base()
        {
            //this.listadoRespuestasPorPregunta = new ClsListadoRespuestasBL().ListadoRespuestasPorPreguntaBL(idPregunta);
        }


        public ObservableCollection<ClsRespuesta> ListadoRespuestasPorPregunta
        {
            get
            {
                return listadoRespuestasPorPregunta;
            }
            set
            {
                listadoRespuestasPorPregunta = value;
            }
        }
    }
}