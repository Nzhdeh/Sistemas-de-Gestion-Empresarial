using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _06_ExamenSorpresaMVC.Models;

namespace _06_ExamenSorpresaMVC.Utilidades
{
    public class GestionDepartamentos
    {
        public static List<ClsDepartamento> listaDepartamentos()
        {
            List<ClsDepartamento> lista = new List<ClsDepartamento>();
            lista.Add(new ClsDepartamento(1,"Finanzas"));
            lista.Add(new ClsDepartamento(2, "Contabilidad"));
            lista.Add(new ClsDepartamento(3, "Ventas"));
            lista.Add(new ClsDepartamento(4, "Ninduno"));

            return lista;
        }

        public String nombreDepartamentoPorID(int id) 
        {
            List<ClsDepartamento> lista = listaDepartamentos();
            String nombre=" ";
            bool encontrado = false;

            for(int i = 0; i < 4 && encontrado==false ; i++) 
            {
                if (lista[i].Id == id) 
                {
                    nombre = lista[i].Nombre;
                    encontrado = true;
                }
            }

            return nombre;
        }
    }
}