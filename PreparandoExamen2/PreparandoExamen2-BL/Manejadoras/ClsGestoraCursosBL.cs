using PreparandoExamen2_DAL.Manejadoras;
using PreparandoExamen2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreparandoExamen2_BL.Manejadoras
{
    public class ClsGestoraCursosBL
    {
        public ClsCurso BuscarCursoPorIdBL(int id)
        {
            ClsGestoraCursosDAL g = new ClsGestoraCursosDAL();
            ClsCurso c = new ClsCurso();

            c = g.BuscarCursoPorIdDAL(id);

            return c;
        }


        public int BorrarCursoPorIdBL(int id)
        {
            ClsGestoraCursosDAL g = new ClsGestoraCursosDAL();
            int resultado = 0;

            resultado = g.BorrarCursoPorIdDAL(id);

            return resultado;
        }


        public int InsertarCursoBL(ClsCurso curso)
        {
            ClsGestoraCursosDAL g = new ClsGestoraCursosDAL();
            int resultado = 0;

            resultado = g.InsertarCursoDAL(curso);

            return resultado;
        }


        public int ActualizarCursoBL(ClsCurso curso)
        {
            ClsGestoraCursosDAL g = new ClsGestoraCursosDAL();
            int resultado = 0;

            resultado = g.ActualizarCursoDAL(curso);

            return resultado;

        }
    }
}