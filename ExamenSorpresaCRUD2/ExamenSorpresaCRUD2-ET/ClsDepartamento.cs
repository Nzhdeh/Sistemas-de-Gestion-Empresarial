using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSorpresaCRUD2_ET
{
    public class ClsDepartamento
    {
        public ClsDepartamento()
        {

        }

        public ClsDepartamento(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}
