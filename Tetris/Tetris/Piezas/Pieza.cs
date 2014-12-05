using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Piezas
{
    public class Pieza
    {
        List<Cuadro> PiezaO;
        IPieza pieza { get; set; }
        public Pieza(IPieza _pieza,Point co)
        {
            pieza = _pieza;
            PiezaO = pieza.Formar(co);
        }
        public void Dibujar(PictureBox pb)
        {
            pieza.Dibujar(ref PiezaO, pb);
        }
        public bool MoverAbajo(Tablero tab)
        {
           return pieza.MoverAbajo(ref PiezaO, tab);
        }
        public void MoverDerecha(Tablero tab)
        {
            pieza.MoverDerecha(ref PiezaO,tab);
        }
        public void MoverIzquierda(Tablero tab)
        {
            pieza.MoverIzquierda(ref PiezaO, tab);
        }
        public void Rotar(Tablero tab)
        {
            
        }

    }
}
