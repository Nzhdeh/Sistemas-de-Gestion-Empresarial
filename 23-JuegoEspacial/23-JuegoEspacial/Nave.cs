using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_JuegoEspacial
{
    public class Nave
    {
        public Nave(double posX,double posY,double velocidad)
        {
            this.posX = posX;
            this.posY = posY;
            this.velocidad = velocidad;
        }
        public double posX { get; set; }
        public double posY { get; set; }
        public double velocidad { get; set; }
    }
}
