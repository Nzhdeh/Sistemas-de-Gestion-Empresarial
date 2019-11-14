﻿using _10_CRUDPersonaDalWeb.Listados;
using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CRUDPersonaBLWeb.Listados
{
    public class ClsListadoPersonasBL
    {
        public List<ClsPersona> ListadoPersonas()
        {
            List<ClsPersona> lista;

            ClsListadoPersonasDAL listadoPersonasDAL = new ClsListadoPersonasDAL();

            lista = listadoPersonasDAL.ObtenerListadoPersonasDAL();

            return lista;
        }
    }
}