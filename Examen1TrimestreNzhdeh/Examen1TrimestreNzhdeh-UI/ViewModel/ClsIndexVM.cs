using Examen1TrimestreNzhdeh_BL.ListasBL;
using Examen1TrimestreNzhdeh_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//me hace falta un metodo para actualizar la tabla 
//misiones de la bbdd el cual recibiria un array 
//de los ids de las misiones seleccionadas y 
//actualizaria el campo reservada a 1,pero no lo hago porque no funciona nada

/*No nuciona: Basicamente*/
namespace Examen1TrimestreNzhdeh_UI.ViewModel
{
    public class ClsIndexVM
    {
        private List<ClsSuperheroe> listadoVengadores;
        private ClsSuperheroe vengadorSeleccionado;
        private List<ClsMision> listadoMisionesNoReservadas;
        private List<int> listadoMisionEliegida;

        public ClsIndexVM()
        {
            ClsListadoDeVengadoresBL lv= new ClsListadoDeVengadoresBL();
            this.listadoVengadores = lv.ListadoCompletoVengadoresBL();
            this.vengadorSeleccionado = new ClsSuperheroe();
        }

        public ClsIndexVM(List<ClsSuperheroe> listadoVengadores,ClsSuperheroe vengador)
        {
            ClsListadoDeMisionesNoReservadasBL lm = new ClsListadoDeMisionesNoReservadasBL();
            this.listadoVengadores = listadoVengadores;
            this.vengadorSeleccionado = vengador;
            this.listadoMisionesNoReservadas = lm.ListadoDeMisionesNoReservadasBL();
        }

        public ClsIndexVM(List<ClsSuperheroe> listadoVengadores, ClsSuperheroe vengador,List<ClsMision> clsMisions)
        {
            this.listadoVengadores = listadoVengadores;
            this.vengadorSeleccionado = vengador;
            this.listadoMisionesNoReservadas = clsMisions;
            //a lo mejor añado el listado de misiones elegidas
        }

        public List<ClsSuperheroe> ListadoVengadores
        {
            get
            {
                return listadoVengadores;
            }
        }

        public List<ClsMision> ListadoMisionesNoReservadas
        {
            get
            {
                return listadoMisionesNoReservadas;
            }
        }

        public ClsSuperheroe VengadorSeleccionado
        {
            get
            {
                return vengadorSeleccionado;
            }
            set
            {
                vengadorSeleccionado = value;
            }
        }

        public List<int> ListadoMisionEliegida
        {
            get
            {
                return listadoMisionEliegida;
            }
            set
            {
                listadoMisionEliegida = value;
            }
        }
    }
}