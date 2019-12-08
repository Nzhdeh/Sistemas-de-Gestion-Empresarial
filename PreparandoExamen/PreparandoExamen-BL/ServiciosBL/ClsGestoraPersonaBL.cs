using PreparandoExamen_DAL.ServiciosDAL;
using PreparandoExamen_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen_BL.ServiciosBL
{
    public class ClsGestoraPersonaBL
    {
        public ClsPersona BuscarPersonaPorIdBL(int id) 
        {
            ClsGestoraPersonaDAL g = new ClsGestoraPersonaDAL();
            ClsPersona p = new ClsPersona();
            p = g.BuscarPersonaPorIdDAL(id);

            return p;
        }

        public int BorrarPersonaPorIdBL(int id)
        {
            int resultado = 0;
            ClsGestoraPersonaDAL gestoraPersonaDAL = new ClsGestoraPersonaDAL();
            resultado = gestoraPersonaDAL.BorrarPersonaPorIdDAL(id);

            return resultado;
        }

        public int InsertarPersonaBL(ClsPersona persona)
        {
            int resultado = 0;

            ClsGestoraPersonaDAL gestoraPersonaDAL = new ClsGestoraPersonaDAL();
            resultado = gestoraPersonaDAL.InsertarPersonaDAL(persona);

            return resultado;
        }

        public int ActualizarPersonaBL(ClsPersona persona)
        {
            int resultado = 0;

            ClsGestoraPersonaDAL gestoraPersonaDAL = new ClsGestoraPersonaDAL();
            resultado = gestoraPersonaDAL.ActualizarPersonaDAL(persona);

            return resultado;
        }
    }
}