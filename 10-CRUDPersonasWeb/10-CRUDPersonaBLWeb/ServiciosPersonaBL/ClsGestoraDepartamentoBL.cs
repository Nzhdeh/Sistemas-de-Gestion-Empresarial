using _10_CRUDPersonaDalWeb.ServiciosPersonaDAL;
using _10_CRUDPersonaEntidadesWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CRUDPersonaBLWeb.ServiciosPersonaBL
{
    public class ClsGestoraDepartamentoBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClsDepartamento BuscarDepartamentoPorId(int id)
        {
            ClsDepartamento departamento;
            ClsGestoraDepartamentoDAL gestoraDepartamentoDAL = new ClsGestoraDepartamentoDAL();
            departamento = gestoraDepartamentoDAL.buscarDepartamentoPorID(id);

            return departamento;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public ClsDepartamento BuscarDepartamentoPorNombre(String nombre)
        {
            ClsDepartamento departamento;
            ClsGestoraDepartamentoDAL gestoraDepartamentoDAL = new ClsGestoraDepartamentoDAL();
            departamento = gestoraDepartamentoDAL.buscarDepartamentoPorNombre(nombre);

            return departamento;
        }
    }
}
