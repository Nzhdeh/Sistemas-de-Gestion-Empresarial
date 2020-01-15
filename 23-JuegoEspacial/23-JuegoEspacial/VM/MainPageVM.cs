using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace _23_JuegoEspacial.VM
{
    public class MainPageVM: ClsVMBase
    {
        private DispatcherTimer dispatcherTimer { get; set; }
        private Nave _nave;

        public MainPageVM() //constructor
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1); //para comprobar cada milisegundo si se esta pulsando alguna tecla
            dispatcherTimer.Tick += timerTick; //para que cada milisegundo que se comprueba realice alguna funcion en este caso timerTick
            moviendoX = false;
            moviendoY = false;
            _nave = new Nave(500, 500, 0);

        }

        private void timerTick(object sender, object e)
        {
            move();
        }


        public void move()
        {
            Double posicionFutura;
            if (moviendoY)
            {
                posicionFutura = _nave.posY + _nave.velocidad;
                if (posicionFutura > 0 && posicionFutura < 500)
                {
                    _nave.posY += _nave.velocidad;
                }
            }

            if (moviendoX)
            {
                posicionFutura = _nave.posX + _nave.velocidad;
                if (posicionFutura > 0 && posicionFutura < 1180)
                {
                    _nave.posX += _nave.velocidad;
                }
            }
            NotifyPropertyChanged("nave");

        }


        public void Grid_KeyDown(object sender, KeyRoutedEventArgs e) //Grid_KeyDown es el nombre que yo le he dado se puede llamar como querais
        {
            if (e.Key == VirtualKey.Up) //movimiento flecha arriba
            {
                arriba();
                dispatcherTimer.Start(); //empieza el dispatcherTimer
                moviendoY = true;
                moviendoX = false;
            }

            if (e.Key == VirtualKey.Down)//movimiento flecha abajo
            {
                abajo();
                dispatcherTimer.Start();
                moviendoY = true;
                moviendoX = false;
            }

            if (e.Key == VirtualKey.Right) //movimiento flecha derecha
            {
                derecha();
                dispatcherTimer.Start();
                moviendoX = true;
                moviendoY = false;
            }

            if (e.Key == VirtualKey.Left)//movimiento flecha izquierda
            {
                izquierda();
                dispatcherTimer.Start();
                moviendoX = true;
                moviendoY = false;
            }
        }

        //Si dejamos de pulsar la tecla tendra que realizar una funcion que pare el dispatcherTimer

        public void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Up || e.Key == VirtualKey.Down || e.Key == VirtualKey.Left || e.Key == VirtualKey.Right)
            {
                dispatcherTimer.Stop();
                moviendoY = false;
                moviendoX = false;
            }
        }

        public bool moviendoY { get; set; }

        public bool moviendoX { get; set; }

        public Nave nave
        {
            get
            {
                return _nave;

            }
            set
            {
                _nave = value;
            }
        }

        public void abajo()
        {
            if (_nave.posY < 500)
            {
                _nave.velocidad = 10;
            }
            else
            {
                _nave.velocidad = 0;
            }
        }

        public void arriba()
        {
            if (_nave.posY > 0 && _nave.posY - 10 > 0)
            {
                _nave.velocidad = -10;
            }
            else
            {
                _nave.velocidad = 0;
            }
        }

        public void derecha()
        {
            if (_nave.posX < 1180)
            {
                _nave.velocidad = 10;
            }
            else
            {
                _nave.velocidad = 0;
            }
        }
        public void izquierda()
        {
            if (_nave.posX > 0 && _nave.posX - 10 > 0)
            {
                _nave.velocidad = -10;
            }
            else
            {
                _nave.velocidad = 0;
            }
        }

    }
}
