﻿using CuestionarioCoronavirusDAL.Conexion;
using CuestionarioCoronavirusDAL.ListadosDAL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusBL.ListadosBL
{
    public class ClsListadoRespuestasBL
    {
        /// <summary>
        /// sirve para obtener las respuestas de una pregunta por su id
        /// </summary>
        /// <param name="id"> id de la pregunta</param>
        /// <returns>listasdo de respuestas de una pregunta</returns>

        public ObservableCollection<ClsRespuesta> ListadoRespuestasPorPreguntaBL(int id)
        {
            ClsListadoRespuestasDAL listado=null;

            ObservableCollection<ClsRespuesta> listadoRespuestas = new ObservableCollection<ClsRespuesta>();

            try
            {
                listado = new ClsListadoRespuestasDAL();
                listadoRespuestas = listado.ListadoRespuestasPorPreguntaDAL(id);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoRespuestas;
        }
    }
}
